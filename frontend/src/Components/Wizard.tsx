import * as React from "react";
import { TagWizard } from "@tag/tag-components-react-v2";
import { WizardStep } from "./WizardStep";
import { QuestionResponseModel } from "../Models/QuestionResponseModel";
import { QuizModel } from "../Models/QuizModel";
import { QuestionModel } from "../Models/QuestionModel";
import { useState, useEffect } from "react";
import { StartQuiz } from "../Services/QuestionService";
import { TagText } from "@tag/tag-components-react-v3";
import { SubmitQuiz } from "../Services/QuizService";

interface WizardProps {
  quiz: QuizModel;
}

export const Wizard = (props: WizardProps) => {
  const [questions, setQuestions] = useState<QuestionModel[]>([]);
  const [answers, setAnswers] = useState<QuestionResponseModel[]>([]);

  useEffect(() => {
    StartQuiz(props.quiz.id, props.quiz.course.id)
      .then((r) => setQuestions(r))
      .catch((e) => console.log(e));
  }, []);
  const Submit = (arr: any) => {
    SubmitQuiz(props.quiz.course.id, props.quiz.id, arr)
      .then((r) => console.log("submitted"))
      .catch((e) => console.log(e));
  };

  const handleButtonsClick = (
    answer: QuestionResponseModel,
    submit: boolean = false
  ) => {
    let currentAnswer = answers.find((a) => a.questionId === answer.questionId);
    if (currentAnswer) {
      const arr = answers.filter((a) => a.questionId !== answer.questionId);
      arr.push(answer);
      submit ? Submit(arr) : setAnswers(arr);
    } else {
      const arr = [...answers];
      arr.push(answer);
      submit ? Submit(arr) : setAnswers(arr);
    }
  };
  const handleFinish = (answer: QuestionResponseModel) => {
    handleButtonsClick(answer, true);
  };
  return questions.length > 0 ? (
    <TagWizard heading={props.quiz.name}>
      {questions.map((q) => (
        <WizardStep
          key={q.id}
          question={q}
          handleButtonsClick={handleButtonsClick}
          handleFinish={handleFinish}
          heading={props.quiz.name}
        />
      ))}
    </TagWizard>
  ) : (
    <TagText text="Initializing..." type="h2" />
  );
};
