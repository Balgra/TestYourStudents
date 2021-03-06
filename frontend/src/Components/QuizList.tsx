import { QuizModel } from "../Models/QuizModel";
import { TagList } from "@tag/tag-components-react-v2";
import { useState } from "react";
import React from "react";
import { QuestionsModal } from "./QuestionsModal";
import { AddQuestionModal } from "./AddQuestionModal";
import { Wizard } from "./Wizard";

interface QuizListProps {
  quizzes: QuizModel[];
  role: string;
  onForceRefresh: () => void;
}

export const QuizList = (props: QuizListProps) => {
  const [questionsModalVisible, setQuestionsModalVisible] = useState(false);
  const [addQuestionModalVisible, setAddQuestionModalVisible] = useState(false);
  const [selectedQuiz, setSelectedQuiz] = useState<QuizModel>();
  const [attendQuiz, setAttendQuiz] = useState(false);
  const handleButtonClick = (buttonIndex: number, item: QuizModel) => {
    if (buttonIndex === 1) {
      setSelectedQuiz(item);
      setQuestionsModalVisible(true);
    }
    if (buttonIndex === 2) {
      setSelectedQuiz(item);
      setAddQuestionModalVisible(true);
    }
    if (buttonIndex === 3) {
      setSelectedQuiz(item);
      setAttendQuiz(true);
    }
  };

  const WizardForceRefresh = () => {
    props.onForceRefresh();
    setAttendQuiz(false);
  };

  const friendlyDate = (date: Date) => {
    return new Intl.DateTimeFormat("en-GB", {
      dateStyle: "full",
      timeStyle: "long",
    }).format(new Date(date));
  };

  const listData = props.quizzes.map((q: QuizModel) => {
    var time = new Date();
    return {
      ...q,
      leftField: `Can be opened between ${friendlyDate(
        q.startTime
      )} - ${friendlyDate(q.endTime)}`,
      visible: q.visibleForStudents
        ? "Visible for students"
        : "Not visible for students",
      time: q.numberOfMinutes + " minutes",
      enterQuizDisabled:
        time < q.startTime || time > q.endTime || q.submissions.length > 0,
    };
  });
  return attendQuiz && selectedQuiz ? (
    <Wizard quiz={selectedQuiz} onForceRefresh={WizardForceRefresh} />
  ) : (
    <>
      <TagList
        height="330px"
        data={listData}
        onButtonClick={(e) => {
          handleButtonClick(e.detail.buttonIndex, e.detail.item);
        }}
        primaryField="name"
        leftField1="leftField"
        leftField1Icon="CalendarTick"
        leftField1IconAccent="access"
        leftField2={props.role === "Professor" ? "visible" : ""}
        leftField2Icon={props.role === "Professor" ? "Users" : ""}
        leftField2IconAccent="viridiangreen"
        button3DisabledField="enterQuizDisabled"
        rightField1="time"
        rightField1Icon="Clock"
        rightField1IconAccent="midnightblue"
        button1Icon={props.role === "Professor" ? "View" : ""}
        button2Icon={props.role === "Professor" ? "Plus" : ""}
        button3Icon={props.role === "Student" ? "ArrowBottomRight" : ""}
      />
      {selectedQuiz ? (
        <>
          <QuestionsModal
            questions={selectedQuiz.questions}
            quizName={selectedQuiz.name}
            visible={questionsModalVisible}
            setVisible={setQuestionsModalVisible}
          />
          <AddQuestionModal
            visible={addQuestionModalVisible}
            setVisible={setAddQuestionModalVisible}
            quizId={selectedQuiz.id}
            courseId={selectedQuiz.course.id}
            onQuestionAdd={() => props.onForceRefresh()}
          />
        </>
      ) : (
        <></>
      )}
    </>
  );
};
