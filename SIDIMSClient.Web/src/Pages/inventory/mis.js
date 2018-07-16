import React, { Component } from "react";
import { Tab, Tabs } from "react-bootstrap";
import axios from 'axios';
import SelectInput from "../../Components/common/SelectInput";
import moment from 'moment';
import DateRangePicker from 'react-bootstrap-daterangepicker';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-daterangepicker/daterangepicker.css';


import { lookupDropDown } from "../../_selector/selectors";

class Inventory extends Component {
  constructor(props, context) {
    super(props, context);

    this.onChange = this.onChange.bind(this);
    this.onSaveIssuance = this.onSaveIssuance.bind(this);
    this.onSaveReceipt = this.onSaveReceipt.bind(this);

    this.state = {
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

  handleEvent(event, picker) {
    event.preventDefault();
    console.log(picker);
    console.log(picker.endDate._d);
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
      this.getProductStockList(value);
    }
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
          this.getProductStockList(productId);
        })
        .catch(function (error) {
          console.log(error);
        })

    }
  }

  render() {

    const clients = lookupDropDown(this.props.clients);
    const products = lookupDropDown(this.state.products);

    const { issuanceQuantity, receiptQuantity, clientId, productId, remark, description, stockReports, dateRange, search } = this.state;
    let filteredStocks;

    if(stockReports) {
      filteredStocks  = stockReports.filter((stock) => {
          console.log(stock.totalQtyIssued);
          var startDate = new Date("2018-07-13");
          var endDate = new Date("2018-07-19");

          return (
            stock.createdOn >= startDate
          );
        }
      );

      console.log(filteredStocks);
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
                        {dropProducts()}


                        <Tabs
                          defaultActiveKey={1}
                          animation={false}
                          id="noanim-tab-example">

                          <Tab eventKey={1} title="Card Issuance">
                            <div data-style="padding-top:10px">
                              <br />
                              <input
                                type="text"
                                name="remark"
                                value = {remark}
                                onChange={this.onChange}
                                placeholder="Job Description"
                              />
                              <input
                                type="text"
                                name="issuanceQuantity"
                                value = {issuanceQuantity}
                                onChange={this.onChange}
                                placeholder=" Issuance Quantity"
                              />
                              <input type="submit" value="Submit"  onClick = {this.onSaveIssuance} />
                            </div>
                          </Tab>
                          <Tab eventKey={2} title="Received Stock">
                            <div data-style="padding-top:10px">
                              <br />
                              <input
                                type="text"
                                name="description"
                                value = {description}
                                onChange={this.onChange}
                                placeholder="Description"
                              />
                              <input
                                type="text"
                                name="receiptQuantity"
                                value = {receiptQuantity}
                                onChange={this.onChange}
                                className="search-field"
                                placeholder=" Receive Quantity"
                              />

                              <input type="submit" value="Submit" onClick = {this.onSaveReceipt} />
                            </div>
                          </Tab>
                        </Tabs>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div className="col-lg-8">

              <DateRangePicker onEvent={this.handleEvent}>
                <input value = {dateRange} onChange={this.onChange} placeholder="Date Range" />
              </DateRangePicker>
            

                <header>
                  <h2>
                    <i className="fa fa-credit-card" aria-hidden="true" />{" "}
                    &nbsp; FBN Master Card Debit
                  </h2>
                  <p>&nbsp;</p>
                </header>

                <div className="row">
                  <div className="col-md-12">

                
                    <input type="text" value = {this.state.search} onChange={this.updateSearch.bind(this)} />

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
