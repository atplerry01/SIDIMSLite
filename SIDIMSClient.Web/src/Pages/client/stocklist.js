import React, { Component } from "react";
import { Tab, Tabs } from "react-bootstrap";
import axios from 'axios';
import moment from 'moment';
import DatePicker from 'react-datepicker';
import ReactToPrint from "react-to-print";
import {NavLink} from 'react-router-dom';
import 'react-datepicker/dist/react-datepicker.css';

import SelectInput from "../../Components/common/SelectInput";
import { lookupDropDown } from "../../_selector/selectors";

import ExampleCustomInput from '../../Components/calender/ExampleCustomInput';

class Inventory extends Component {
  constructor(props, context) {
    super(props, context);

    this.onChange = this.onChange.bind(this);
    this.onSaveIssuance = this.onSaveIssuance.bind(this);
    this.onSaveReceipt = this.onSaveReceipt.bind(this);
    this.handleStartDateChange = this.handleStartDateChange.bind(this);
    this.handleEndDateChange = this.handleEndDateChange.bind(this);
    this.onDateFilter = this.onDateFilter.bind(this);

    this.state = {
      filterChange: false,
      productName: '',
      startDate: moment(),
      endDate: moment(),
      search: '',
      productId: '',
      clientId: '',
      remark: '',
      dateRange: '',
      description: '',
      issuanceQuantity: '',
      receiptQuantity: ''
    };
  }

  componentWillMount() {
    const { match: { params } } = this.props;
    this.getProductStockList(params.id);
    this.setState({ selectedProductId: params.id });

    const productId = params.id;

    axios.get('http://localhost:5000/api/clients/' + 1 + '/products/' + productId + '/stocklists')
    .then(response => {
      console.log( response.data[0]);
    })
    .catch(function (error) {
    })

    // get Product
    axios.get('http://localhost:5000/api/products/' + productId)
    .then(response => {
      this.setState({ productName: response.data });
    })
    .catch(function (error) {
    })

    axios.get('http://localhost:5000/api/clients/' + 1 + '/products')
      .then(response => {
        console.log(response.data);
        this.setState({ products: response.data });
      })
      .catch(function (error) {
        console.log(error);
      })

  }
  
  getProductStockList(productId) {
    console.log(productId);
    axios.get('http://localhost:5000/api/clients/' + 1 + '/products/' + productId + '/stocklists')
      .then(response => {
        console.log( response.data);
        //this.setState({ stockReports: response.data });
      })
      .catch(function (error) {
      })
  }

  componentWillReceiveProps(nextProps) {
      console.log(nextProps.match.params.id);

    const productId = nextProps.match.params.id;

     // get Product
     axios.get('http://localhost:5000/api/products/' + productId)
     .then(response => {
       this.setState({ productName: response.data });
     })
     .catch(function (error) {
     })

    axios.get('http://localhost:5000/api/clients/' + 1 + '/products/' + productId + '/stocklists')
      .then(response => {
        console.log(response.data);
        this.setState({ stockReports: response.data });
      })
      .catch(function (error) {
      })

    // if (this.props.issueTracker.id !== nextProps.issueTracker.id) {
    //     // Necessary to populate form when existing course is loaded directly.
    //     this.setState({ issueTracker: Object.assign({}, nextProps.issueTracker) });
    // }
    }

  onDateFilter() {
    //this.getProductStockList(this.state.selectedProductId);

    const {startDate, endDate, stockReports} = this.state;
    let dateFilteredStocks = [];

    var start = moment(startDate._d).format('L');
    var end = moment(endDate._d).format('L');

    if (stockReports) {
      dateFilteredStocks  = stockReports.filter(
        (stock) => {
          let rawDate = moment(stock.createdOn).format('L');

          if (start <= rawDate && end >= rawDate) {
             dateFilteredStocks.push(stock);
          }

          return (
            start <= rawDate && end >= rawDate
          );
        }
      );

      
      this.setState({stockReports: dateFilteredStocks});
      console.log(dateFilteredStocks);
    }

    //console.log(filteredStocks);
    this.setState({stockReports: dateFilteredStocks, filterChange:true});

  }

  handleStartDateChange(date) {

    if (this.state.filterChange == true) {
      this.getProductStockList(this.state.selectedProductId);
    }

    this.setState({
      startDate: date
    });
  }

  handleEndDateChange(date) {
    
    if (this.state.filterChange == true) {
      this.getProductStockList(this.state.selectedProductId);
    }
    
    this.setState({
      endDate: date
    });
  }

  handleEvent(event, picker) {
    event.preventDefault();
  }

  updateSearch(e) {
    this.setState({search: e.target.value.substr(
      0,20
    )});
  }
  
  onChange(e) {
    const { name, value } = e.target;
    this.setState({ [name]: value });

    if (name === "clientId" && value !== null) {
      this.getProduct(value);
    }

    if (name === "productId") {
      console.log(value);
      this.getProductById(value);
      this.getProductStockList(value);
    }
  }

  getProductById(productId) {
    axios.get('http://localhost:5000/api/products/' + productId)
      .then(response => {
        console.log( response.data)
        this.setState({ productName: response.data });
      })
      .catch(function (error) {
      })
  }

  getProduct(clientId) {
    axios.get('http://localhost:5000/api/clients/' + clientId + '/products')
      .then(response => {
        this.setState({ products: response.data });
      })
      .catch(function (error) {
      })
  };

  getProductStockList(productId) {
    axios.get('http://localhost:5000/api/clients/' + 1 + '/products/' + productId + '/stocklists')
      .then(response => {
        this.setState({ stockReports: response.data });
      })
      .catch(function (error) {
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
          this.getProductStockList(productId);
        })
        .catch(function (error) {
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
          this.getProductStockList(productId);
        })
        .catch(function (error) {})

    }
  }

  render() {

    let filteredStocks;

    const clients = lookupDropDown(this.props.clients);
    const products = lookupDropDown(this.state.products);
    const { issuanceQuantity, receiptQuantity, clientId, productId, remark, description, stockReports, dateRange, search } = this.state;

    
    if(stockReports) {
      filteredStocks  = stockReports.filter((stock) => {
          return (
            stock.fileName.toLowerCase().indexOf(this.state.search) !== -1 ||
            stock.qtyIssued >= search
          );
        }
      );
    }
    

    const dropClients = () => {
      if (clients) {
        return (
          <SelectInput
            name="clientId"
            label=" Clients"
            value= {clientId}
            onChange={this.onChange}
            defaultOption="Select Client"
            options={clients}
          />
        );
      }
    };

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

    const productTables = () => {
      if (this.state.products) {
        return this.state.products.map((product, index) => {
          return (
            <li key={product.id}>
              <NavLink to={'/mis/' + product.id}>{product.name}</NavLink>
            </li>
          )
        })
      }
    }

    const stockReportTable = () => {
      if (stockReports) {
        return filteredStocks.map((stock, index) => {
          return(
            <tr key={index}>
              <th scope="row">{index +1 }</th>
              <td>{stock.fileName}</td>
              <td>{stock.totalQtyIssued}</td>
              <td>{stock.openingStock}</td>
              <td>{stock.closingStock}</td>
              <td>{stock.currentStock}</td>
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
                      <h4>All Product List</h4>

                      <div>

                        {dropClients()}
                        {productTables()}

                      </div>
                    </div>


                    
                  </div>
                </div>
              </div>

              <div className="pull-right">
                <ReactToPrint
                  trigger={() => <a href="#"> <i className="fa fa-print" style={{ fontSize: '18px' }} aria-hidden="true"></i> Print this out!</a>}
                  content={() => this.componentRef}
                />                
              </div>


              <div className="col-lg-8" ref={el => (this.componentRef = el)}>
                <header>
                  <h2>
                    <i className="fa fa-credit-card" aria-hidden="true" />{" "}
                    &nbsp; {this.state.productName.name}
                  </h2>

                </header>

                <div className="row">
                  <div className="col-md-12">
                    
                  <div className="row" style={{margin: '20px 0 20px'}}>
                      <div className="col-lg-4">
                          <input type="text" value = {this.state.search} onChange={this.updateSearch.bind(this)} placeholder=" Search Job Remark" />
                      </div>
                      <div className="col-lg-4 pull-right">
                        <div className="row">
                          <div className="col-lg-4">
                            <DatePicker
                              customInput={<ExampleCustomInput />}
                              selected={this.state.startDate}
                              onChange={this.handleStartDateChange}
                              showYearDropdown dateFormatCalendar="MMMM"
                              scrollableYearDropdown
                              yearDropdownItemNumber={3} /></div>

                          <div className="col-lg-4">
                            <DatePicker
                              customInput={<ExampleCustomInput />}
                              selected={this.state.endDate}
                              onChange={this.handleEndDateChange}
                              showYearDropdown dateFormatCalendar="MMMM"
                              scrollableYearDropdown
                              yearDropdownItemNumber={3} />
                          </div>
                          <div className="col-lg-4">
                            <input type="submit" value="Filter" className="btn btn-primary"  onClick = {this.onDateFilter} />
                          </div>
                        </div>
                      </div>
                  </div>

                    <table className="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">File Desc</th>
                          <th scope="col">Total Issued</th>
                          <th scope="col">Opening Stock</th>
                          <th scope="col">Closing Stock</th>
                          <th scope="col">Current Stock</th>
                          <th>Date</th>
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

export default Inventory;
