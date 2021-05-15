import { TagEditField, TagModal } from "@tag/tag-components-react-v2";
import {
  TagButton,
  TagText,
  TagPills,
  TagPill,
} from "@tag/tag-components-react-v3";
import React, { useEffect, useRef, useState } from "react";
import { Toast } from "../Components/Toast";
import { ToastModel } from "../Models/Utils/ToastModel";
import { GetCurrentUserRole } from "../Services/AuthService";
import { GetCourses } from "../Services/CourseService";
import { EnrollStudents } from "../Services/EnrollStudentsService";
import { GetQuizzes } from "../Services/QuizService";
import { QuizModel } from "../Models/QuizModel";
import { QuizList } from "../Components/QuizList";

export const HomePage = () => {
  const [role, setRole] = useState<"Professor" | "Student">();
  const [course, setCourse] = useState<any>();
  const [quizzes, setQuizzes] = useState<QuizModel[]>([]);
  const [enrollStudentsModalVisible, setEnrollStudentsModalVisible] =
    useState(false);
  const [enrollInput, setEnrollInput] = useState("");
  const [possibleStudents, setPossibleStudents] = useState<string[]>([]);
  const [toast, setToast] = useState<ToastModel>();
  const enrollStudentInput: any = useRef(null);
  useEffect(() => {
    setRole(GetCurrentUserRole());
    GetCourses().then((response) => {
      setCourse(response);
      GetQuizzes(response.id).then((res) => {
        setQuizzes(res);
      });
    });
  }, []);

  const handleInputKeyPress = (e: any) => {
    if (e.detail.key !== "Enter") return;
    let enrolled = [...possibleStudents];
    enrolled.push(enrollInput);
    setEnrollInput("");
    setPossibleStudents(enrolled);
  };

  const handleEnrollSubmit = () => {
    setPossibleStudents([]);
    setEnrollInput("");
    EnrollStudents(possibleStudents, course.id)
      .then(() => {
        setToast({
          type: "information",
          text: "Students enrolled successfully!",
        });
      })
      .catch((e) => setToast({ type: "danger", text: e }));
  };
  const handleEnrollModalClose = () => {
    setEnrollStudentsModalVisible(false);
    setPossibleStudents([]);
    setEnrollInput("");
  };

  return (
    <div className="container">
      {role === "Professor" && course ? (
        <>
          <div
            style={{ width: "100%" }}
            className="d-flex justify-content-between my-5"
          >
            <TagText type="h2" text={course.name} />
            <TagButton
              accent="white"
              icon="Plus"
              iconAccent="keppel"
              text="Enroll students"
              size="large"
              onButtonClick={() => setEnrollStudentsModalVisible(true)}
            />
          </div>

          <TagModal
            visible={enrollStudentsModalVisible}
            onClosed={() => handleEnrollModalClose()}
            onOpened={() =>
              setTimeout(
                () =>
                  enrollStudentInput?.current?.tagComponent?.current?.focusEditor(),
                100
              )
            }
            heading="Enroll students"
            headingBackgroundAccent="border"
            primaryButton="Enroll"
            primaryButtonAccent="keppel"
            borderAccent="dolphinblue"
            onPrimaryButtonClick={() => handleEnrollSubmit()}
          >
            <div>
              <TagEditField
                ref={enrollStudentInput}
                label="Add a student"
                value={enrollInput}
                placeholder="Enter a student email"
                onValueChange={(e) => setEnrollInput(e.detail.value)}
                onEditorKeypress={(e) => handleInputKeyPress(e)}
                validation={[{ rule: "email" }]}
                className="mt-3"
              />

              {possibleStudents.length > 0 ? (
                <div>
                  <TagText text="Emails added" />

                  {possibleStudents.map((e) => (
                    <TagPills key={e}>
                      <TagPill>{e}</TagPill>
                    </TagPills>
                  ))}
                </div>
              ) : (
                <></>
              )}
            </div>
          </TagModal>
        </>
      ) : (
        <></>
      )}
      {role && quizzes.length > 0 ? (
        <QuizList role={role} quizzes={quizzes} />
      ) : (
        <></>
      )}
      <Toast type={toast?.type} text={toast?.text} />
    </div>
  );
};
