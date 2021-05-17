import { TagEditField, TagModal } from "@tag/tag-components-react-v2";
import React, { useState } from "react";
import { makeStyles, TextField } from "@material-ui/core";
import { CreateQuiz } from "../Services/QuizService";

interface CreateQuizModalProps {
  visible: boolean;
  courseId: number;
  setVisible: () => void;
  onForceRefresh: () => void;
}
const useStyles = makeStyles((theme) => ({
  container: {
    display: "flex",
    flexWrap: "wrap",
  },
  textField: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    width: 200,
  },
}));

export const CreateQuizModal = (props: CreateQuizModalProps) => {
  const [name, setName] = useState("");
  const [startTime, setStartTime] = useState<Date>(new Date());
  const [endTime, setEndTime] = useState<Date>(new Date());
  const [numberOfMinutes, setNumberOfMinutes] = useState(0);
  const [visibleForStudents, setVisibleForStudents] = useState(true);
  const classes = useStyles();

  const handleSubmit = () => {
    const quiz = {
      name,
      startTime,
      endTime,
      numberOfMinutes,
      visibleForStudents,
    };
    CreateQuiz(props.courseId, quiz)
      .then(() => props.onForceRefresh())
      .catch((e) => console.log(e));
  };
  return (
    <TagModal
      visible={props.visible}
      onClosed={() => props.setVisible()}
      heading="Enroll students"
      headingBackgroundAccent="border"
      primaryButton="Create"
      primaryButtonAccent="keppel"
      borderAccent="dolphinblue"
      onPrimaryButtonClick={() => handleSubmit()}
    >
      <div>
        <TagEditField
          label="Name"
          value={name}
          onValueChange={(e) => setName(e.detail.value)}
          validation={[{ rule: "required" }]}
          className="mt-3"
        />
      </div>
      <div className={classes.container + " mt-3"}>
        <TextField
          id="datetime-local"
          label="Start acces time"
          type="datetime-local"
          defaultValue="2017-05-24T10:30"
          className={classes.textField}
          onChange={(e) => setStartTime(new Date(e.target.value))}
          InputLabelProps={{
            shrink: true,
          }}
        />
      </div>
      <div className={classes.container + " mt-3"}>
        <TextField
          id="datetime-local"
          label="End acces time"
          type="datetime-local"
          defaultValue="2017-05-24T10:30"
          className={classes.textField}
          onChange={(e) => setEndTime(new Date(e.target.value))}
          InputLabelProps={{
            shrink: true,
          }}
        />
      </div>
      <div className="mt-3">
        <TagEditField
          editor="number"
          label="Number of minutes"
          value={numberOfMinutes}
          onValueChange={(e) => setNumberOfMinutes(e.detail.value)}
        />
      </div>
      <div className="mt-3">
        <TagEditField
          editor="checkbox"
          label="Visible for students"
          value={visibleForStudents}
          onValueChange={(e) => setVisibleForStudents(e.detail.value)}
        />
      </div>
    </TagModal>
  );
};
