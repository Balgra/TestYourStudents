import { Button, TextField, Typography } from "@material-ui/core";
import { TagEditField } from "@tag/tag-components-react-v2";
import { TagButton, TagText } from "@tag/tag-components-react-v3";
import React, { useEffect } from "react";
import { IsAuthenticated, Login } from "../Services/AuthService";

export const LoginPage = () => {
  let email: string;
  let password: string;

  useEffect(() => {
    console.log(IsAuthenticated());
  }, []);

  const SubmitForm = () => {
    // doamne nu ma lasa ce e aci
    // const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    // const emailValidated = regex.test(email.toLowerCase());
    // const passwordValidated = password.length >= 6;

    Login({ email, password })
      .then(() => console.log(IsAuthenticated()))
      .catch(() => console.log("error"));
    //   if(emailValidated && passwordValidated)
    //       Login(email, password).then((authorized) => authorized ? props.onSuccessfullLogin() : console.log("invalid credentials")).catch(e => console.log(e));
  };
  return (
    <div
      style={{ width: "100%", height: "100%" }}
      className="d-flex justify-content-center align-items-center"
    >
      <div
        style={{
          width: "500px",
          minHeight: "300px",
          padding: "50px",
          boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
        }}
        className="d-flex flex-column justify-content-between"
      >
        <TagText type="h1" accent="viridiangreen" className="mb-5">
          Login
        </TagText>
        <TagEditField
          label="Email"
          dataType="email"
          onValueChange={(e) => (email = e.detail.value)}
          className="my-3"
        />
        <TagEditField
          label="Password"
          editor="password"
          onValueChange={(e) => (password = e.detail.value)}
          className="my-3"
        />
        <TagButton
          accent="viridiangreen"
          onClick={() => SubmitForm()}
          onButtonClick={() => SubmitForm()}
          className="mt-5"
          text="Login"
        ></TagButton>
      </div>
    </div>
  );
};
