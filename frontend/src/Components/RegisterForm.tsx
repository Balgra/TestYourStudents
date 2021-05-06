import React, { useState } from "react";
import { TagEditField } from "@tag/tag-components-react-v2";
import { TagButton } from "@tag/tag-components-react-v3";

interface RegisterFormProps {
  type: "Student" | "Professor";
}

export const RegisterForm = (props: RegisterFormProps) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [courseName, setCourseName] = useState("");

  const SubmitForm = () => {
    // doamne nu ma lasa ce e aci
    const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const emailValidated = regex.test(email.toLowerCase());
    const passwordValidated = password.length >= 6;
  };
  //   if(emailValidated && passwordValidated)
  //       Login(email, password).then((authorized) => authorized ? props.onSuccessfullLogin() : console.log("invalid credentials")).catch(e => console.log(e));
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
        value={password}
        editor="password"
        onValueChange={(e) => setPassword(e.detail.value)}
        className="mt-3"
      />
      <TagButton
        accent="viridiangreen"
        onClick={() => SubmitForm()}
        text="Register"
        className="mt-3"
      ></TagButton>
    </div>
  );
};
