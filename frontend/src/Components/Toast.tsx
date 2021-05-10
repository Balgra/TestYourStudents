import { TagAlert, TagToast } from "@tag/tag-components-react-v2";
import React from "react";
import { ToastModel } from "../Models/Utils/ToastModel";

export const Toast = (props: ToastModel) => {
  return props.type && props.text ? (
    <TagToast position="bottom-right">
      <TagAlert
        type={props.type}
        text={props.text}
        showDuration={3000}
        alertType="toast"
        closeable
      ></TagAlert>
    </TagToast>
  ) : (
    <></>
  );
};
