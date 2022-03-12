
/* -------------- Student -----------------*/
//stud_login & teacher_login
function blank() {
    swal({
        title: "Oops!",
        text: "Please enter Email ID and password!",
        icon: "warning",
    });
}

function pwd_err() {
    swal({
        title: "Oops!",
        text: "Password is not match!",
        icon: "warning",
    });
}
function wrongg() {
    swal({
        title: "Oops!",
        text: "Something is wrong",
        icon: "warning",
    });
}
function pwd_success() {
    swal({
        title: "Yeah!",
        text: "Password is changed successfully!",
        icon: "success",
    });
}
function success() {
    swal({
        title: "Success!",
        text: "Welcome",
        icon: "success",
    });
}
function not_approved() {
    swal({
        title: "Oops!",
        text: "Please wait for approve your account.. !",
        icon: "error",
    });
}
function wait() {
    swal({
        title: "Oops!",
        text: "You are blocked !",
        icon: "error",
    });
}

function hey() {
    swal({
        title: "Oops!",
        text: "Email Id and password is wrong!",
        icon: "error",
    });
}

//stud_login and teacher_login (SIGN UP)
function blank_all() {
    swal({
        title: "Oops!",
        text: "Please enter all details!",
        icon: "warning",
    });
}
function done() {
    swal({
        title: "Done!",
        text: "Registration Successfully!",
        icon: "success",
    });
}
function len() {
    swal({
        title: "Oops!",
        text: "Please enter only 10digit number!",
        icon: "error",
    });
}
function nan() {
    swal({
        title: "Oops!",
        text: "Please enter only numbers!",
        icon: "error",
    });
}
function nan_p() {
    swal({
        title: "Oops!",
        text: "Please enter only numbers in Phone number!",
        icon: "error",
    });
}
function err_eno() {
    swal({
        title: "Oops!",
        text: "Enrollment Number is already Exist!",
        icon: "warning",
    });
}
function email_error() {
    swal({
        title: "Oops!",
        text: "Email is already Exist!",
        icon: "warning",
    });
}
function ph_error() {
    swal({
        title: "Oops!",
        text: "Phone number is already Exist!",
        icon: "warning",
    });
}
function image_error() {
    swal({
        title: "Oops!",
        text: "Image file must be .jpg or .jpeg type!",
        icon: "warning",
    });
}

//for teacher_login
function err_tid() {
    swal("Oops!", "Teacher ID is already Exist !", "warning");
}

/* -------------- WEBFORMS -----------------*/
//contact_us
function done_contact() {
    swal("Done!", "Thank you for your feedback/message", "success");
}

//issue_entry
function already_book() {
    swal("Oops!", "This user have already this book!", "warning");
}
function error_qty() {
    swal("Oops!", "This book is not available in stock!", "warning");
}
function done_entry() {
    swal("Good Job!", "Book Entry successfully..!", "success");
}
function err_entry() {
    swal("Oops!", "You are already request for issuing this book...!", "error");
}

//lost
function lost_entry_done() {
    swal("Done!", "Lost Book Entry successfully..!", "success");
}
/* -------------- WEBFORMS > Update -----------------*/
//dept
function dept_error() {
    swal("Oops!", "Please enter new Departments..!", "warning");
}
function dept_updated() {
    swal("Success!", "Department/s are Updated..!", "success");
}

//dp
function done_dp() {
    swal("Success!", "Profile Updated Successfully..!", "success");
}
function remove_dp() {
    swal("Success!", "Profile Removed Successfully..!", "success").then((value) =>{
        swal("This is only Default picture don\'t worry");
    });   
}

//phno
function phno_error() {
    swal("Oops!", "Please enter new Phone number..!", "warning");
}
function updated() {
    swal("Yeah!", "Update Successfully!", "success");
}

//sem
function sem_error() {
    swal("Oops!", "Please Enter new semester!", "warning");
}
function sem_invalid() {
    swal("Oops!", "Please Enter only 1 to 6 new semester!", "warning");
}
function sem_min() {
    swal("Oops!", "Minimize sem not allowed!", "error");
}

/*------------------------Librarian-------------------- */
//add_books
function pdf_error() {
    swal("Oops!", "PDF file must be .pdf type!", "warning");
}
function vdo_error() {
    swal("Oops!", "Video file must be .mp4 type!", "warning");
}
function done_add_books() {
    swal("Great!", "Your books added successfully...!", "success");
}

//Edit_page
function done_edit_books() {
    swal("Great!", "Your books added successfully...!", "success");
}

//issue_entry

function done_issue_entry() {
    swal({
        title: "Great2!",
        text: "Book issued successfully...!",
        icon: "success",

    }).then((value) => {
        return ('https://google.com');
    });
}

//lost
function done_lost() {
    swal("Great!", "Payment Received and Book added into lost books!", "success");
}

//new_issue_book
function select_book_error(){
    swal("Oops!", "Please select file!", "warning");
}
//penalty
function inserted(){
    swal("Yeah!", "Insert Successfully!", "warning");
}


//add_librarian

function done_add_lnm() {
    swal("Great!", "New Librarian added successfully...!", "success");
}
