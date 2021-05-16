import React, { useState } from "react";
import { QuestionModel } from "../Models/QuestionModel";
import { TagWizardStep, TagEditField } from "@tag/tag-components-react-v2";

type WizardStepProps = {
  question: QuestionModel;
  handleButtonsClick: (a: any) => void;
  handleFinish: (a: any) => void;
  heading: string;
};
export const WizardStep = (props: WizardStepProps) => {
  const [answer, setAnswer] = useState("");
  return (
    <TagWizardStep
      heading={props.heading}
      contentContainerStyle={{
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-around",
      }}
      onNextClick={() =>
        props.handleButtonsClick({
          questionId: props.question.id,
          questionResponse: answer,
        })
      }
      onPreviousClick={() =>
        props.handleButtonsClick({
          questionId: props.question.id,
          questionResponse: answer,
        })
      }
      onFinishClick={() =>
        props.handleFinish({
          questionId: props.question.id,
          questionResponse: answer,
        })
      }
    >
      <TagEditField
        containerStyle={{
          marginTop: "30px",
          display: "flex",
          flexDirection: "column",
        }}
        value={answer}
        label={props.question.questionName}
        placeholder="Your opinion"
        editor="multilinetextbox"
        rows={3}
        onValueChange={(e) => setAnswer(e.detail.value)}
      />
    </TagWizardStep>
  );
};
