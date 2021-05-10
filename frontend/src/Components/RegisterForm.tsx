import React, { useState } from "react";
import { TagEditField } from "@tag/tag-components-react-v2";
import { TagButton } from "@tag/tag-components-react-v3";
import { ToastModel } from "../Models/Utils/ToastModel";
import {
  RegisterAsProfessor,
  RegisterAsStudent,
} from "../Services/AuthService";
import { Toast } from "./Toast";

interface RegisterFormProps {
  type: "Student" | "Professor";
}

export const RegisterForm = (props: RegisterFormProps) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [courseName, setCourseName] = useState("");
  const [toast, setToast] = useState<ToastModel>();

  const SubmitForm = () => {
    // doamne nu ma lasa ce e aci
    const regex =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const emailValidated = regex.test(email.toLowerCase());
    const passwordValidated = password === confirmPassword;
    const valid = emailValidated && passwordValidated;

    if (!emailValidated)
      setToast({ text: "The email is invalid!", type: "danger" });
    else if (!passwordValidated)
      setToast({ text: "Passwords doesn't match!", type: "danger" });

    if (valid)
      if (props.type === "Student")
        RegisterAsStudent({ email, password, firstName, lastName })
          .then((response) => {
            setToast({ text: response, type: "information" });
          })
          .catch((e) => setToast({ text: e, type: "danger" }));
      else if (props.type === "Professor")
        RegisterAsProfessor({
          email,
          password,
          firstName,
          lastName,
          courseName,
        })
          .then((response) => {
            setToast({ text: response, type: "information" });
          })
          .catch((e) => setToast({ text: e, type: "danger" }));
  };
  return (
    <div className="mt-5 d-flex flex-column">
      <TagEditField
        label="Firstname"
        value={firstName}
        onValueChange={(e) => setFirstName(e.detail.value)}
      />
      <TagEditField
        label="Lastname"
        value={lastName}
        onValueChange={(e) => setLastName(e.detail.value)}
        className="mt-3"
      />
      {props.type === "Professor" ? (
        <TagEditField
          label="Course name"
          value={courseName}
          onValueChange={(e) => setCourseName(e.detail.value)}
          className="mt-3"
        />
      ) : (
        <></>
      )}

      <TagEditField
        label="Email"
        value={email}
        dataType="email"
        onValueChange={(e) => setEmail(e.detail.value)}
        className="mt-3"
      />
      <TagEditField
        label="Password"
        value={password}
        editor="password"
        onValueChange={(e) => setPassword(e.detail.value)}
        className="mt-3"
      />
      <TagEditField
        label="Confirm password"
        value={confirmPassword}
        editor="password"
        onValueChange={(e) => setConfirmPassword(e.detail.value)}
        className="mt-3"
      />
      <TagButton
        accent="viridiangreen"
        onButtonClick={() => SubmitForm()}
        text="Register"
        className="mt-3"
      ></TagButton>
      <Toast type={toast?.type} text={toast?.text} />
    </div>
  );
};
