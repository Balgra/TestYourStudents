import { TagText } from "@tag/tag-components-react-v3";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { IsAuthenticated, Logout } from "../Services/AuthService";

export const Navbar = (props: {
  isAuthenticated: boolean;
  handleAuthActions: (s: boolean) => void;
}) => {
  return (
    <nav className="navbar navbar-expand justify-content-around navbar-light bg-light">
      <a className="navbar-brand ml-3" href="/">
        <TagText
          type="h3"
          accent="viridiangreen"
          textStyle={{ fontWeight: "bold" }}
        >
          Test your students
        </TagText>
      </a>

      <div className="navbar navbar-small justify-content-center">
        <div className="navbar-nav">
          <div className="nav-item d-flex align-items-center">
            {!props.isAuthenticated ? (
              <>
                <Link className="nav-link " to="login">
                  <TagText type="p">Login</TagText>
                </Link>
                <Link className="nav-link " to="register">
                  <TagText type="p">Register</TagText>
                </Link>
              </>
            ) : (
              <Link className="nav-link " to="/login">
                <p
                  onClick={() => {
                    Logout();
                    props.handleAuthActions(false);
                  }}
                >
                  Logout
                </p>
              </Link>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
};
