import { useForm, Controller } from "react-hook-form";
import { TextField, Button, Box } from "@mui/material";

const FilterComponent = (props) => {
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    props.onSubmit(data);
  };

  return (
    <>
      <Box
        component="form"
        onSubmit={handleSubmit(onSubmit)}
        sx={{ display: "flex", flexDirection: "row", gap: 2, flexWrap: "wrap" }}
      >
        <Controller
          name="EmpId"
          control={control}
          defaultValue=""
          rules={{ required: "Employee ID is required" }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Employee ID"
              error={!!errors.EmpId}
              helperText={errors.EmpId ? errors.EmpId.message : ""}
            />
          )}
        />

        <Controller
          name="EmpName"
          control={control}
          defaultValue=""
          rules={{ required: "Employee Name is required" }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Employee Name"
              error={!!errors.EmpName}
              helperText={errors.EmpName ? errors.EmpName.message : ""}
            />
          )}
        />

        <Controller
          name="WorkingHours"
          control={control}
          defaultValue=""
          rules={{ required: "Working Hours are required", min: 0 }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Working Hours"
              type="number"
              error={!!errors.WorkingHours}
              helperText={
                errors.WorkingHours ? errors.WorkingHours.message : ""
              }
            />
          )}
        />

        <Controller
          name="BreakHours"
          control={control}
          defaultValue=""
          rules={{ required: "Break Hours are required", min: 0 }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Break Hours"
              type="number"
              error={!!errors.BreakHours}
              helperText={errors.BreakHours ? errors.BreakHours.message : ""}
            />
          )}
        />

        <Controller
          name="From"
          control={control}
          defaultValue=""
          rules={{ required: "From date is required" }}
          render={({ field }) => (
            <TextField
              {...field}
              label="From Date"
              type="date"
              InputLabelProps={{ shrink: true }}
              error={!!errors.From}
              helperText={errors.From ? errors.From.message : ""}
            />
          )}
        />

        <Controller
          name="To"
          control={control}
          defaultValue=""
          rules={{ required: "To date is required" }}
          render={({ field }) => (
            <TextField
              {...field}
              label="To Date"
              type="date"
              InputLabelProps={{ shrink: true }}
              error={!!errors.To}
              helperText={errors.To ? errors.To.message : ""}
            />
          )}
        />

        <Button type="submit" variant="contained" color="primary">
          Submit
        </Button>
      </Box>
    </>
  );
};

export default FilterComponent;
