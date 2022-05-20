<<<<<<< HEAD
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from "react-router-dom";
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Auth0Provider } from "@auth0/auth0-react";
=======
import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App'
import reportWebVitals from './reportWebVitals'
import { Auth0Provider } from '@auth0/auth0-react'
>>>>>>> backupidp

const root = ReactDOM.createRoot(document.getElementById('root'))
root.render(
<<<<<<< HEAD
  <BrowserRouter>
    <Auth0Provider
      domain="dev-rxvajvsu.us.auth0.com"
      clientId="YyrdH0HdCwE8J5ufDw5lUpIPVH1s9fM6"
      redirectUri={window.location.origin}
      // audience="https://dev-rxvajvsu.us.auth0.com/api/v2/"
      // scope="read:current_user update:current_user_metadata"
    >
      <App />
    </Auth0Provider>
  </BrowserRouter>
);
=======
  <Auth0Provider
    domain="dev-rxvajvsu.us.auth0.com"
    clientId="vqXaPyLnv7HeXY45yQNfxLdPrh93FFPw"
    redirectUri={window.location.origin}
  >
    <App />
  </Auth0Provider>
)
>>>>>>> backupidp

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals()
