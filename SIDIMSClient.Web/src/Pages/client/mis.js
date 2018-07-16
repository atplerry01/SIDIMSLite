import React, { Component } from "react";
import { Tab, Tabs } from "react-bootstrap";
import axios from 'axios';
import ReactToPrint from "react-to-print";

import SelectInput from "../../Components/common/SelectInput";

import { lookupDropDown } from "../../_selector/selectors";

class ClientMIS extends Component {
  constructor(props, context) {
    super(props, context);

    this.onChange = this.onChange.bind(this);
    this.onSaveIssuance = this.onSaveIssuance.bind(this);
    this.onSaveReceipt = this.onSaveReceipt.bind(this);

    this.state = {
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

    console.log(e);
    console.log(this.state);

    const { receiptQuantity,  productId, description } = this.state;

    console.log(productId);
    console.log(receiptQuantity);


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

    const { issuanceQuantity, receiptQuantity, clientId, productId, remark, description, stockReports } = this.state;

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
        return stockReports.map((stock, index) => {
          return(
            <tr key={index}>
              <th scope="row">{index +1 }</th>
              <td>{stock.fileName}</td>
              <td>{stock.totalQtyIssued}</td>
              <td>{stock.openingStock}</td>
              <td>{stock.closingStock}</td>
              <td>{stock.currentStock}</td>
              <td>
                <i
                  className="fa fa-pencil-square-o"
                  aria-hidden="true"
                />
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
                    <i className="fa fa-credit-card" aria-hidden="true" />{" "}
                    &nbsp; FBN Master Card Debit
                  </h2>
                  <p>&nbsp;</p>
                </header>

                <div className="row">
                  <div className="col-md-12">
                    <table className="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">File Desc</th>
                          <th scope="col">Total Issued</th>
                          <th scope="col">Opening Stock</th>
                          <th scope="col">Closing Stock</th>
                          <th scope="col">Current Stock</th>
                          <th>Actions</th>
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
