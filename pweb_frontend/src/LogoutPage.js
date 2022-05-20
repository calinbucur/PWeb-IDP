/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
import React from "react";
import './App.css'
import logo from './logo.png';
import { Routes, Route, Link } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";

const LogoutPage = () => {
    const {loginWithRedirect} = useAuth0();
    return (
        <div className="App">
          <header className="App-banner">
            <header className="App-title">
              PetAway
            </header>
            <button className = "BannerButton" onClick={() => loginWithRedirect()}>
              <header className="ButtonText">Sign in</header>
            </button>
          </header>
          <img className = "App-big-logo" src={logo} alt="Logo"/>
          <header className = "App-side-prompt">
            Hundreds of pets from Ukraine need your help.
            <br></br>
            Sign up to save your pet or help save others.
          </header>
        </div>
    );
}

export default LogoutPage;