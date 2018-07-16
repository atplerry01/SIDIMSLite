import React from 'react';
import { NavLink, Link } from "react-router-dom";

const LoginForm = ({ loading }) => {
    const loginCard = {
        margin: '40px 0 0 0'
      };
      
    return (
        <div class="row">
                <div class="col-lg-4">

                    <header>
                        <h2>
                            <span class="icon-pagesx"></span>Account Login</h2>
                      
                    </header>

                    <div>
                        <form>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Email address</label>
                                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Password</label>
                                <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
                            </div>

                            <button type="submit" class="btn btn-primary">Submit</button>


                            <span class="clearfix" />
                        </form>

                    </div>

                </div>


                <div class="col-lg-8">
                    <div class="sidebar">


                    </div>
                </div>
            </div>
    );

};

export default LoginForm
