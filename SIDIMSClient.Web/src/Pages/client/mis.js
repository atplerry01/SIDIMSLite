import React, { Component } from "react";
import { Tab, Tabs } from "react-bootstrap";
import {NavLink} from 'react-router-dom';
import axios from 'axios';
import ReactToPrint from "react-to-print";
import DatePicker from 'react-datepicker';
import moment from 'moment';

import SelectInput from "../../Components/common/SelectInput";
import ExampleCustomInput from '../../Components/calender/ExampleCustomInput';

import { lookupDropDown } from "../../_selector/selectors";

class ClientMIS extends Component {
  constructor(props, context) {
    super(props, context);

    this.onChange = this.onChange.bind(this);
    this.onSaveIssuance = this.onSaveIssuance.bind(this);
    this.onSaveReceipt = this.onSaveReceipt.bind(this);

    this.state = {
      selectedProduct: '',
      productId: '',
      clientId: '',
      remark: '',
      description: '',
      issuanceQuantity: '',
      receiptQuantity: ''
    };
  }

  
  onChange(e) {
    const { name, value } = e.target;
    this.setState({ [name]: value });

    // if (name === "clientId" && value !== null) {
    //   this.getProduct(value);
    // }

    if (name === "productId") {
      console.log(value);
      
      this.getProductStockList(value);
    }
  }

  componentWillMount() {
    this.getClientVaults()
  }
  
  getClientVaults() {
    axios.get('http://localhost:5000/api/clients/1/vaults')
    .then(response => {
      console.log(response.data);
      this.setState({ clientVaults: response.data });
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

  getProductStockList(productId) {
    axios.get('http://localhost:5000/api/clients/' + 1 + '/products/' + productId + '/stocklists')
      .then(response => {
        console.log(response.data);
        this.setState({ stockReports: response.data });
      })
      .catch(function (error) {
        console.log(error);
      })
  }

  onSaveIssuance(e) {
    e.preventDefault();

    const { issuanceQuantity,  productId, remark } = this.state;

    if (issuanceQuantity && productId) {
      var cardIssuance = {
        productId: productId,
        quantity: issuanceQuantity,
        remark: remark
      };

      axios.post('http://localhost:5000/api/cardflows/issuance/create', cardIssuance)
        .then(response => {
          //success
          this.getProductStockList(productId);
        })
        .catch(function (error) {
          console.log(error);
        })

    }
  }

  onSaveReceipt(e) {
    e.preventDefault();

    const { receiptQuantity,  productId, description } = this.state;

    if (receiptQuantity && productId) {

      var cardReceipt = {
        productId: productId,
        quantity: receiptQuantity,
        description: description
      };

      axios.post('http://localhost:5000/api/cardflows/cardreceipt/create', cardReceipt)
        .then(response => {
          //success
          console.log(response);
          this.getProductStockList(productId);
        })
        .catch(function (error) {
          console.log(error);
        })

    }
  }

  onProductSelection(value) {
    console.log(value);
  }

  render() {

    console.log(this.state);
    console.log(this.props);

    const clients = lookupDropDown(this.props.clients);
    const products = lookupDropDown(this.props.products);

    const { issuanceQuantity, receiptQuantity, clientId, productId, remark, description,clientVaults, stockReports } = this.state;

  
    const dropProducts = () => {
      if (products) {
        return (
          <SelectInput
            name="productId"
            label=" Products"
            value= {productId}
            onChange={this.onChange}
            defaultOption="Select Product"
            options={products}
          />
        );
      }
    };
    
    const stockReportTable = () => {
      if (clientVaults) {
        console.log(clientVaults);

        return clientVaults.map((stock, index) => {
          return(
            <tr key={index} >
              <th scope="row">{index +1 }</th>
              <td>
              <NavLink to={'/mis/' + stock.sidProductId}>{stock.sidProduct.name}</NavLink>
              </td>
              <td>{stock.openingStock}</td>
              <td>{stock.currentStock}</td>
              <td>{stock.closingStock}</td>
              <td>
              {moment(stock.modifiedOn).format("DD-MMM-YYYY")}
              </td>
            </tr>
          )
        })
      } 
    }
  

    return (
      <div>
        <section className="topics">
          <div className="container">
            <div className="row">
              <div className="col-lg-4">
                <div className="sidebar" data-style="padding-right:25px">
                  <div>
                    <div className="widget fix widget_categories2">
                      <h4>Product List</h4>
                      <div>
                        {dropProducts()}

                       
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <ReactToPrint
                trigger={() => <a href="#">Print this out!</a>}
                content={() => this.componentRef}
              />

              <div className="col-lg-8" ref={el => (this.componentRef = el)} >
                <header>
                  <h2>
                   Product Reports
                  </h2>
                  <p>&nbsp;</p>
                </header>

                <div className="row">
                  <div className="col-md-12">


                    <table className="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Product Name</th>
                          <th scope="col">Opening Stock</th>
                          <th scope="col">Current Stock</th>
                          <th scope="col">Closing Stock</th>
                          <th>Last Updated</th>
                        </tr>
                      </thead>
                      <tbody>
                        {stockReportTable()}
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>
    );
  }
}

export default ClientMIS;
