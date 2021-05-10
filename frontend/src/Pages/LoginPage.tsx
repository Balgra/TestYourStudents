import { TagEditField } from "@tag/tag-components-react-v2";
import { TagButton, TagText } from "@tag/tag-components-react-v3";
import React, { useEffect, useState } from "react";
import { IsAuthenticated, Login } from "../Services/AuthService";
import { ToastModel } from "../Models/Utils/ToastModel";
import { Redirect } from "react-router";
import { Toast } from "../Components/Toast";

export const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [toast, setToast] = useState<ToastModel>();
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    setLoggedIn(IsAuthenticated());
  }, []);

  const SubmitForm = () => {
    const regex =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const emailValidated = regex.test(email.toLowerCase());

    if (emailValidated)
      Login({ email, password })
        .then((response) => {
          setToast({ text: response, type: "information" });
          setLoggedIn(true);
        })
        .catch((error) => setToast({ text: error, type: "danger" }));
    else setToast({ text: "The email is invalid!", type: "danger" });
  };
  return loggedIn ? (
    <Redirect to="/" />
  ) : (
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
          value={email}
          onValueChange={(e) => setEmail(e.detail.value)}
          validation={[{ rule: "required" }]}
          className="my-3"
        />
        <TagEditField
          label="Password"
          editor="password"
          value={password}
          validation={[{ rule: "required" }]}
          onValueChange={(e) => setPassword(e.detail.value)}
          className="my-3"
        />
        <TagButton
          accent="viridiangreen"
          onClick={() => SubmitForm()}
          onButtonClick={() => SubmitForm()}
          className="mt-5"
          text="Login"
        ></TagButton>
        <Toast type={toast?.type} text={toast?.text} />
      </div>
    </div>
  );
};
