import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@mui/material";
import theme from "../../../utils/theme";
import moment from "moment";

const BreakDetailsDialog = ({ open, onClose, breakDetails }) => {
  return (
    <Dialog open={open} onClose={onClose} maxWidth="xl" fullWidth>
      <DialogTitle>Break Details</DialogTitle>
      <DialogContent>
        <TableContainer
          component={Paper}
          sx={{
            maxHeight: 1000,
            "&::-webkit-scrollbar": { width: 1 },
            "&::-webkit-scrollbar-thumb": { backgroundColor: "#888" },
            "&::-webkit-scrollbar-thumb:hover": { backgroundColor: "#555" },
          }}
        >
          <Table stickyHeader>
            <TableHead>
              <TableRow>
                <TableCell
                  sx={{
                    backgroundColor: theme.palette.common.secondaryColor,
                    color: theme.palette.common.primaryColor,
                    fontWeight: "bold",
                  }}
                >
                  SR
                </TableCell>
                <TableCell
                  sx={{
                    backgroundColor: theme.palette.common.secondaryColor,
                    color: theme.palette.common.primaryColor,
                    fontWeight: "bold",
                  }}
                >
                  From
                </TableCell>
                <TableCell
                  sx={{
                    backgroundColor: theme.palette.common.secondaryColor,
                    color: theme.palette.common.primaryColor,
                    fontWeight: "bold",
                  }}
                >
                  To
                </TableCell>
                <TableCell
                  sx={{
                    backgroundColor: theme.palette.common.secondaryColor,
                    color: theme.palette.common.primaryColor,
                    fontWeight: "bold",
                  }}
                >
                  Duration
                </TableCell>
                <TableCell
                  sx={{
                    backgroundColor: theme.palette.common.secondaryColor,
                    color: theme.palette.common.primaryColor,
                    fontWeight: "bold",
                  }}
                >
                  Reason
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {breakDetails && breakDetails.length > 0 ? (
                breakDetails.map((detail, index) => (
                  <TableRow key={index}>
                    <TableCell>{index + 1}</TableCell>
                    <TableCell>
                      {moment(detail.from).format("YYYY-MM-DD HH:mm:ss")}
                    </TableCell>
                    <TableCell>
                      {moment(detail.to).format("YYYY-MM-DD HH:mm:ss")}
                    </TableCell>

                    <TableCell>{detail.duration}</TableCell>
                    <TableCell>{detail.reason}</TableCell>
                  </TableRow>
                ))
              ) : (
                <TableRow>
                  <TableCell colSpan={5} align="center">
                    No break details available.
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} color="primary">
          Close
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default BreakDetailsDialog;
