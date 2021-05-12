import { TagTabs } from "@tag/tag-components-react-v2";
import { TagText } from "@tag/tag-components-react-v3";
import { RegisterForm } from "../Components/RegisterForm";
import React, { useEffect, useState } from "react";
import { IsAuthenticated } from "../Services/AuthService";
import { Redirect } from "react-router";

export const RegisterPage = (props: { handleLoginSuccess: () => void }) => {
  const [title, setTitle] = useState("Register as student");
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    setLoggedIn(IsAuthenticated());
  }, []);

  if (loggedIn) return <Redirect to="/" />;
  return (
    <div
      style={{ width: "100%", height: "100%" }}
      className="d-flex justify-content-center align-items-center mt-5"
    >
      <div
        style={{
          width: "800px",
          minHeight: "300px",
          padding: "50px",
          boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
        }}
        className="d-flex flex-column justify-content-between"
      >
        <h1 className="mb-5" style={{ color: "#099" }}>
          {title}
        </h1>
        <TagTabs
          tabs={[
            {
              caption: "Register as student",
              name: "student",
              renderContent: () => (
                <RegisterForm
                  handleLoginSuccess={props.handleLoginSuccess}
                  type="Student"
                ></RegisterForm>
              ),
              selected: true,
            },
            {
              caption: "Register as professor",
              renderContent: () => (
                <RegisterForm
                  handleLoginSuccess={props.handleLoginSuccess}
                  type="Professor"
                ></RegisterForm>
              ),
              name: "professor",
              // eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2hubnlAcHJvZmVzc29yLmNvbSIsImp0aSI6ImEwNzIwZWI1LTkwZWItNGJjMC1iMTFhLTlhMjAyNTAxYTBiYiIsImVtYWlsIjoiam9obm55QHByb2Zlc3Nvci5jb20iLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiZmlyc3ROYW1lIjoiUHJvZmVzc29yIiwibGFzdE5hbWUiOiJKb2huIiwidXNlcklkIjoiNzc5Mjc5ZTgtYjc3ZC00NDE2LTlmOGEtZDY2NWI5YjE5NWYxIiwicm9sZSI6IlByb2Zlc3NvciIsIm5iZiI6MTYyMDg0NTE5MywiZXhwIjoxNjI5NDg1MTkzLCJpYXQiOjE2MjA4NDUxOTN9.r2ORAu9XHbqYvdYo2LMGQVbi2flqMsmRSvWeZHUtn-w
            },
          ]}
          onTabChange={(e) => setTitle(e.detail.caption)}
        />
      </div>
    </div>
  );
};
