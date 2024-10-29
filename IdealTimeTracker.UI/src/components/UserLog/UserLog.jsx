import {
  Button,
  Pagination,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import "./UserLog.css";
import Paper from "@mui/material/Paper";
import { useEffect, useState } from "react";
import { exportDataToExcel } from "../../utils/excel";
import theme from "../../utils/theme";
import { workingHours } from "../../utils/admin.config";
import { excelTypeAll } from "../../utils/contants";
import { toast } from "react-toastify";
import UserLogFilter from "../Filter/UserLogFilter";
import {
  getFilterLogForUser,
  getFilterLogForUserExcel,
} from "../../Service/log.service";
import BreakDetailsDialog from "../Modal/BreakDetails/BreakDetailsDialog";
import moment from "moment";

function UserLog() {
  const tableColums = [
    "S.NO",
    "Date",
    "Emp Name",
    "EMPID",
    "Check in",
    "Check out",
    "Working Hours",
    "Number ofBreak",
    "Break Hours",
  ];

  // const [searchterm, setSearchterm] = useState("");
  // const [activities, setActivities] = useState([]);
  // const [currentDate, setCurrentDate] = useState(now);

  // const handleChange = (event) => {
  //   setSearchterm(event.target.value);
  // };

  const [userId, seUserId] = useState(sessionStorage.getItem("userID"));
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPage, setTotalPage] = useState(1);
  const [excelSuccess, setExcelSuccess] = useState(true);
  const [activities, setActivities] = useState(true);
  const [breaks, setBreaks] = useState();
  const [isOPen, SetIsOpen] = useState(false);

  const handleBreak = (data) => {
    if (data?.length > 0) {
      setBreaks(data);
      SetIsOpen(true);
    }
  };

  const handleClose = () => {
    setBreaks();
    SetIsOpen(false);
  };

  const [filter, setFilter] = useState({
    EmpId: "",
    EmpName: "",
    WorkingHours: 0,
    BreakHours: 0,
    From: new Date(),
    To: new Date(),
    PageNumber: 1,
    ManagerId: "",
  });

  const handleSubmit = (data) => {
    const payload = {
      EmpId: data.EmpId,
      EmpName: data.EmpName,
      WorkingHours: data.WorkingHours,
      BreakHours: data.BreakHours,
      From: data.From,
      To: data.To,
      PageNumber: 1,
      ManagerId: userId,
    };

    setCurrentPage(1);

    console.log(data, payload);

    setFilter(payload);
    getAllFilteredLogs(payload);
  };

  const handlePageChangeSubmit = () => {
    const payload = {
      EmpId: filter.EmpId,
      EmpName: filter.EmpName,
      WorkingHours: filter.WorkingHours,
      BreakHours: filter.BreakHours,
      From: filter.From,
      To: filter.To,
      PageNumber: currentPage,
      ManagerId: userId,
    };

    setFilter(payload);
    getAllFilteredLogs(payload);
  };

  const getAllFilteredLogs = (payload) => {
    getFilterLogForUser(payload)
      .then((res) => {
        setActivities(res.data.logs);
        setTotalPage(res.data.totalPages);
        setCurrentPage(res.data.currentPage);
      })
      .catch((error) => {
        console.error("Error fetching filtered logs:", error);
        // Handle error accordingly
      });
  };

  useEffect(() => {
    handlePageChangeSubmit();
  }, [currentPage, userId]);

  const handlePagination = (event, value) => {
    setCurrentPage(value);
  };

  // useEffect(() => {
  //   if (now) {
  //     getAllLogs({
  //       reportingToId: userId,
  //       start: now.startOf("months").format("YYYY-MM-DD"),
  //       end: now.endOf("month").format("YYYY-MM-DD"),
  //       pageNumber: currentPage,
  //     }).then((res) => {
  //       setActivities(res.data.logs);
  //       setTotalPage(res.data.totalPages);
  //     });
  //   }
  // }, [now, currentPage]);

  // const handleDate = (direction) => {
  //   const updatedDate = now.clone().add(direction, "month"); // Clone and add/subtract month
  //   setNow(updatedDate);
  // };

  const handleDownload = () => {
    const columns = [
      { header: "S no", key: "sno", width: 32 },
      { header: "Date", key: "date", width: 32 },
      { header: "EMPID", key: "empId", width: 32 },
      { header: "Number of break", key: "noOfBreak", width: 32 },
      { header: "Check In", key: "checkIn", width: 32 },
      { header: "Check Out", key: "checkOut", width: 32 },
      { header: "workingHours", key: "workingHours", width: 32 },
      { header: "breakHours", key: "breakHours", width: 32 },

      // Adjust width as needed
    ];
    setExcelSuccess(false);
    toast.info("Excel Report started");

    const payload = {
      EmpId: filter.EmpId,
      EmpName: filter.EmpName,
      WorkingHours: filter.WorkingHours,
      BreakHours: filter.BreakHours,
      From: filter.From,
      To: filter.To,
      PageNumber: currentPage,
      ManagerId: userId,
    };
    getFilterLogForUserExcel(payload)
      .then(async (res) => {
        setExcelSuccess(true);
        console.log(res, "res");
        res.data = res.data.map((entry) => ({
          ...entry,
          checkIn: moment(entry.checkIn).format("MM/DD/YYYY HH:mm:ss"),
          checkOut: moment(entry.checkOut).format("MM/DD/YYYY HH:mm:ss"),
          date: moment(entry.date).format("MM/DD/YYYY"),
        }));
        await exportDataToExcel(
          columns,
          res.data,
          excelTypeAll,
          `${filter.EmpId}_${moment(filter.From).format(
            "YYYY-MM-DD HH-mm-ss"
          )}+${moment(filter.To).format("YYYY-MM-DD HH-mm-ss")}`
        );
        toast.success("Excel Report Generated");
      })
      .catch((error) => {
        console.log(error, "errpr");
        toast.error("Excel Report failed");
        setExcelSuccess(true);
      });
  };

  return (
    <div className="log-container">
      <div className="log-header">
        <h1>log </h1>

        <div>
          <Button
            variant="contained"
            sx={{
              backgroundColor: theme.palette.common.secondaryColor,
              color: theme.palette.common.primaryColor,
            }}
            disabled={!excelSuccess || activities.length == 0}
            onClick={handleDownload}
          >
            Download Excel
          </Button>
        </div>
        {/* <div className="log-date-container">
            <div className="log-date">
              <ArrowBackIosNewIcon
                onClick={() => {
                  handleDate(-1);
                }}
                className="log-arrow"
              />
              Month : {now.format("MMMM YYYY")}
              <ArrowForwardIosIcon
                onClick={() => {
                  handleDate(1);
                }}
                className="log-arrow"
              />
            </div>
          </div>
          <div className="log-btn">
            <TextField
              className="search-box"
              id="outlined-error"
              label="Search EMP Ids"
              value={searchterm}
              onChange={handleChange}
            />
          
          </div> */}
      </div>

      <div className="log-filter">
        <UserLogFilter onSubmit={handleSubmit} />
      </div>

      <div className="log-content">
        <TableContainer
          component={Paper}
          sx={{
            maxHeight: 500,
            "&::-webkit-scrollbar": { width: 1 },
            "&::-webkit-scrollbar-thumb": { backgroundColor: "#888" },
            "&::-webkit-scrollbar-thumb:hover": { backgroundColor: "#555" },
          }}
        >
          <Table stickyHeader>
            <TableHead>
              <TableRow>
                {tableColums.map((col, index) => (
                  <TableCell
                    sx={{
                      backgroundColor: theme.palette.common.secondaryColor,
                      color: theme.palette.common.primaryColor,
                      fontWeight: "bold",
                    }}
                    key={index}
                  >
                    {col}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {activities.length > 0 ? (
                activities.map((Activity, index) => (
                  <TableRow key={index}>
                    <TableCell>{index + 1}</TableCell>
                    <TableCell>
                      {moment(Activity.date).format("YYYY-MM-DD")}
                    </TableCell>
                    <TableCell>{Activity.empName}</TableCell>
                    <TableCell>{Activity.empId}</TableCell>
                    <TableCell>
                      {moment(Activity.checkIn).format("YYYY-MM-DD HH:mm:ss")}
                    </TableCell>
                    <TableCell>
                      {moment(Activity.checkOut).format("YYYY-MM-DD HH:mm:ss")}
                    </TableCell>
                    <TableCell>{Activity.workingHours}</TableCell>

                    <TableCell
                      sx={{
                        cursor: "pointer",
                      }}
                      onClick={() => handleBreak(Activity.breaks)}
                    >
                      {Activity.breaks.length ?? 0}
                    </TableCell>
                    <TableCell>{Activity.breakHours}</TableCell>
                  </TableRow>
                ))
              ) : (
                <TableRow>
                  <TableCell colSpan={tableColums.length} align="center">
                    No records
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <div className="user-log-pagination">
          <Pagination
            page={currentPage}
            count={totalPage}
            onChange={handlePagination}
            color="primary"
          />
        </div>

        <BreakDetailsDialog
          open={isOPen}
          onClose={handleClose}
          breakDetails={breaks}
        />
      </div>
    </div>
  );
}

export default UserLog;
