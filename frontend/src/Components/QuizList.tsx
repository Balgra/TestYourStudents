import { QuizModel } from "../Models/QuizModel";
import { TagList } from "@tag/tag-components-react-v2";

interface QuizListProps {
  quizzes: QuizModel[];
  role: string;
}

export const QuizList = (props: QuizListProps) => {
  const handleButtonClick = (buttonIndex: number, item: any) => {};

  const friendlyDate = (date: Date) => {
    return new Intl.DateTimeFormat("en-GB", {
      dateStyle: "full",
      timeStyle: "long",
    }).format(new Date(date));
  };

  const listData = props.quizzes.map((q) => {
    return {
      ...q,
      leftField: `Can be opened between ${friendlyDate(
        q.startTime
      )} - ${friendlyDate(q.endTime)}`,
      visible: q.visibleForStudents
        ? "Visible for students"
        : "Not visible for students",
      time: q.numberOfMinutes + " minutes",
    };
  });
  return (
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
      leftField2="visible"
      leftField2Icon="Users"
      leftField2IconAccent="viridiangreen"
      button1DisabledField="disabled"
      button2DisabledField="disabled"
      rightField1="time"
      rightField1Icon="Clock"
      rightField1IconAccent="midnightblue"
    />
  );
};
