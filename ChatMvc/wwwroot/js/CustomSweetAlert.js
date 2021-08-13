function ErrorMessage(title , message) {
    swal({
        title: title,
        text: message,
        icon: "error",
    });
}

function InfoMessage(title, message) {
    swal({
        title: title,
        text: message,
        icon: "info",
    });
}

function SuccessMessage(title = "", message = "") {
    let resMessage = message === "" ? "Operation Successfull" : message;
    let resTitle = title;
    swal({
        title: resTitle,
        text: resMessage,
        type: "success",
        timer: 1000,
        icon: "success",
    });    
}