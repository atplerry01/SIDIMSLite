import React, { Component } from "react";
import { Router, Route, Switch } from "react-router-dom";
import axios from 'axios';
import { history } from "../_helpers/history";
import '../assets/css/custome.css';

import About from "../Pages/anonymous/About";
import Header from "../Components/common/Header";
import Footer from "../Components/common/Footer";
import NoMatch from "../Components/common/NoMatch";

import Dashboard from "../Pages/dashboard/Dashboard";
import LoginPage from '../Components/login/LoginForm';

import ClientMIS from "../Pages/client/mis";
import Inventory from "../Pages/inventory/mis";

class App extends Component {

  constructor(props, context) {
    super(props, context);

    var ls = localStorage.getItem("wss.auth");
    var jwtToken = JSON.parse(ls);
    var auth = false;

    if (jwtToken) auth = true;

    this.state = {
      authenticated: auth
    };

    this.toggleAuthentication  =this.toggleAuthentication.bind(this);
    this.handleLogout  = this.handleLogout.bind(this);
  }

  componentDidMount() {
    this.getClient();
    this.getProduct(1);
  }

  getClient() {
      axios.get('http://localhost:5000/api/clients')
      .then(response => {
        this.setState({ clients: response.data });
      })
      .catch(function (error) {
        console.log(error);
      })
  }

  
  getProduct(clientId) {
    axios.get('http://localhost:5000/api/clients/' + clientId + '/products')
      .then(response => {
        console.log(response.data);
        this.setState({ products: response.data });
      })
      .catch(function (error) {
        console.log(error);
      })
  };


  toggleAuthentication() {
    var ls = localStorage.getItem("wss.auth");
    var jwtToken = JSON.parse(ls);
    var auth = false;

    if (jwtToken) auth = true;

    this.setState({
      authenticated: auth
    });
  }

  handleLogout() {
    this.setState({ authenticated: false });
    this.props.actions.logout();
  }

  render() {
    const relativePath = history.location.pathname;
    const contentWrapper = { padding: 0 };

    {this.getProducts}

    return (
      <Router  history={history} {...this.state}>
        <div>
          <Header pathName = {relativePath} />

          <main className="content-wrapper" style={contentWrapper}>
            <div className="container">
              <Switch>
                <Route path="/" exact component={Dashboard} />
                <Route path="/about" component={About} />

                <Switch>

                    <Route path="/mis" exact render={() => (<ClientMIS {...this.state} />)} />
                    <Route path="/inventory" exact render={() => (<Inventory {...this.state} />)} />

                    <Route path="/login" render={(routeProps) => (<LoginPage changeLoginAuth={this.toggleAuthentication} {...routeProps} {...this.props} {...this.state}/>)} />

                </Switch>

              </Switch>
            </div>
          </main>

        </div>
      </Router>
      

    );
  }
}

export default App;
