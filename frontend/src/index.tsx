import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import {
  applyPolyfills,
  defineCustomElements as defineCustomElements_v3,
} from "@tag/tag-components-v3/loader";

ReactDOM.render(
  <React.StrictMode>
    <div
      style={{ height: "100vh" }}
      className="container-fluid d-flex flex-column"
    >
      <App />
    </div>
  </React.StrictMode>,
  document.getElementById("root")
);
applyPolyfills().then(() => {
  defineCustomElements_v3();
});

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
