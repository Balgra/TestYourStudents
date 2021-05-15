import { TagEditField, TagModal } from "@tag/tag-components-react-v2";
import React, { useState } from "react";
import { CreateQuestion } from "../Services/QuestionService";

interface AddQuestionModalProps {
  visible: boolean;
  setVisible: (e: boolean) => void;
  courseId: number;
  quizId: number;
  onQuestionAdd: () => void;
}

export const AddQuestionModal = (props: AddQuestionModalProps) => {
  const [question, setQuestion] = useState("");

  const handleAddButton = () => {
    CreateQuestion(question, props.courseId, props.quizId)
      .then(() => props.onQuestionAdd())
      .catch((e) => console.log(e));
  };

  return (
    <TagModal
      visible={props.visible}
      onClosed={() => props.setVisible(false)}
      heading="Add question"
      headingBackgroundAccent="border"
      primaryButton="Add"
      primaryButtonAccent="keppel"
      borderAccent="dolphinblue"
      onPrimaryButtonClick={() => handleAddButton()}
    >
      <TagEditField
        label="Add a question"
        value={question}
        placeholder="Enter a question"
        onValueChange={(e) => setQuestion(e.detail.value)}
        validation={[{ rule: "required" }]}
        className="mt-3"
      />
    </TagModal>
  );
};
