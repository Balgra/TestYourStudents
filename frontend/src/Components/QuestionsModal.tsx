import { TagList, TagModal } from "@tag/tag-components-react-v2";
import { QuestionModel } from "../Models/QuestionModel";
import React from "react";

interface QuestionsModalProps {
  questions: QuestionModel[];
  visible: boolean;
  setVisible: (e: boolean) => void;
  quizName: string;
}

export const QuestionsModal = (props: QuestionsModalProps) => {
  return (
    <TagModal
      visible={props.visible}
      onClosed={() => props.setVisible(false)}
      heading={props.quizName + " questions"}
      headingBackgroundAccent="border"
      primaryButton="Close"
      primaryButtonAccent="keppel"
      borderAccent="dolphinblue"
      onPrimaryButtonClick={() => () => props.setVisible(false)}
    >
      <TagList data={props.questions} primaryField="questionName" />
    </TagModal>
  );
};
