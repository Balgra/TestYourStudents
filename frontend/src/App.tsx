import React, { useEffect, useState } from "react";
import { Navbar } from "./Components/Navbar";
import { LoginPage } from "./Pages/LoginPage";
import { RegisterPage } from "./Pages/RegisterPage";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { IsAuthenticated, Login } from "./Services/AuthService";

function App() {
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    if (IsAuthenticated()) setLoggedIn(true);
  }, []);

  return (
    <Router>
      <Navbar isAuthenticated={loggedIn} handleAuthActions={setLoggedIn} />

      {loggedIn ? (
        <Switch>
          <Route path="/" />
        </Switch>
      ) : (
        <Switch>
          <Route
            path="/login"
            exact
            render={() => (
              <LoginPage handleLoginSuccess={() => setLoggedIn(true)} />
            )}
          />
          <Route
            path="/register"
            exact
            render={() => (
              <RegisterPage handleLoginSuccess={() => setLoggedIn(true)} />
            )}
          />
          <Route
            render={() => (
              <LoginPage handleLoginSuccess={() => setLoggedIn(true)} />
            )}
          />
        </Switch>
      )}
    </Router>
  );
}

export default App;
