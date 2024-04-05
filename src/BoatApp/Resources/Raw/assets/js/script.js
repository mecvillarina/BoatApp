var userOTP = 0;
var owner_id = '';
$(document).ready(function () {

    /* .......................... start splash screen ........................... */
    if($(".splashPg_main").length>0){
        setTimeout(()=>{
            $(".splashPg_main").addClass("go_nextPage");
            setTimeout(()=>{
                window.location.href="login.html"
            },450)
        },2500);
    }
    /* .......................... end splash screen ........................... */

    /* .......................... start login/otp page ........................... */
    // login form validation
    $("#login_form").validate({
        rules: {
            phone_number: {
                required: true,
                pattern: /^\+1\s?\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$/ // Validates USA phone number format with country code
            }
        },
        messages: {
            phone_number: {
                required: "Please enter your phone number.",
                pattern: "Please enter a valid USA phone number including the country code (+1)."
            }
        },
        errorPlacement: function(error, element) {
            if ($(element).attr("name") === "phone_number") {
                $(error).appendTo(".phone_err");
            } else {
                $(error).insertAfter(element); // Default error placement for other fields
            }
        },
        errorElement: "div", // Set the error element to be a div
        errorClass: "is-invalid",
        submitHandler: function(form) {
            // This function is called when the form is successfully validated
            // You can perform your custom actions here, such as sending data to the server
            // For example, you can use jQuery's $.ajax() to send the form data to a server endpoint
            
            // Uncomment the following code to send the form data to a server (example using jQuery AJAX):
            /*
            $.ajax({
                url: "your-server-endpoint-url",
                method: "POST",
                data: $(form).serialize(), // Serialize the form data
                success: function(response) {
                    // Handle the success response from the server
                    console.log("Form submitted successfully.");
                },
                error: function(xhr, textStatus, errorThrown) {
                    // Handle errors, if any
                    console.error("Form submission failed:", errorThrown);
                }
            });
            */

            // redirecting to otp page for demo purpose. 
            window.location.href="otp.html"
        }
    });

    // otp input
    $('#otp').pincodeInput({
        hidedigits: false, 
        inputs: 5,
        complete: function (value, e, errorElement) {
            userOTP = value;
            console.log(value);
        }
    });

    $("#login_form").validate({
        submitHandler: function(form) {
        window.location.href="home.html"
        }
    });
    /* .......................... end login/otp page ........................... */

   
})

function loadHomePage(owner_id)
{
    $.ajax(
        {
        url: "https://us-east-2.aws.data.mongodb-api.com/app/data-dwyeq/endpoint/data/v1",
        headers: {
            'api-key': 'G1HLYwNa0jWevlzpenxkXMGAS79NUsMN5NmIYi7vqA4NP7pxSfFTZiEPBqeZKtGO',
            'Access-Control-Request-Headers': '*',
            'User-Agent': 'PostmanRuntime/7.28.4',
            'Accept': '*/*',
        },
        contentType: "application/json",
        method: "POST",
        data: {owner_id: owner_id},
        dataType: "json",
        success: function(response) {
            $("apiResponse").html(response);
            //console.log(response);
        }
    });
    //
}


function loadHomePageStatic(response)
{
    console.log(response);
    //$("#apiResponse").html(response);

    var json = JSON.parse(response);

    console.log(json);

    $.each(json.documents,function(key, value){
        // console.log(key, value)
        var html = '<div class="col-12"><div class="card"><div class="position-relative rounded_6 overflow-hidden"><img class="card_img img-fluid w-100" src="'+value.image_url+'" alt=""></div><div class="pt-2"><div class="row align-items-end gx-2"><div class="col-6"><h6 class="fs_14 fw-medium mb_6">'+value.boat_name+'</h6><ul class="card_info"><li><i class="fi fi-rr-marker"></i> '+value.parking_location.address+'</li><li><i class="fi fi-rr-ship"></i> '+value.parking_location.dock+' , '+value.parking_location.zone+'</li></ul></div><div class="col-6">';
        var requestButton = '<a class="btn btn_sm btn_primary w-100"  href="home.html?owner_id='+owner_id+'&boat_number='+value.boat_number+'"><i class="fi fi-rr-arrow-up-right me-1"></i> Request Drop</a>';
        if(value.request_status == "drop_request_submitted"){requestButton= '<a class="btn btn_sm rounded-pill btn_request_submitted w-100" href="drop_off_details.html">Drop Request Submitted</a>';}
        html = html + requestButton +'</div></div></div></div></div>';
        console.log(value.boat_name,value.parking_location.address);
        // alert(value.picturePath);
        // alert(html);
        $('#apiResponse').append(html);

    });
}

function showOwnerDetails(response)
{
    console.log(response);
    //$("#apiResponse").html(response);

    var json = JSON.parse(response);

    console.log(json);

    var ownerDetails = json.documents[0];

    $('#ownerName').text("Welcome "+ownerDetails.name);

    $('#memberSince').text("Member Since "+ownerDetails.member_since);
    $('#profilePic').text("Member Since "+ownerDetails.profile_pic);
    owner_id = ownerDetails._id;
    console.log(owner_id);

    // $.each(json.documents,function(key, value){
    //     // console.log(key, value)
    //     var html = '<div class="col-12"><div class="card"><div class="position-relative rounded_6 overflow-hidden"><img class="card_img img-fluid w-100" src="'+value.image_url+'" alt=""></div><div class="pt-2"><div class="row align-items-end gx-2"><div class="col-6"><h6 class="fs_14 fw-medium mb_6">'+value.boat_name+'</h6><ul class="card_info"><li><i class="fi fi-rr-marker"></i> '+value.parking_location.address+'</li><li><i class="fi fi-rr-ship"></i> '+value.parking_location.dock+' , '+value.parking_location.zone+'</li></ul></div><div class="col-6">';
    //     var requestButton = '<button class="btn btn_sm btn_primary w-100"><i class="fi fi-rr-arrow-up-right me-1"></i> Request Drop</button>';
    //     if(value.request_status == "drop_request_submitted"){requestButton= '<a class="btn btn_sm rounded-pill btn_request_submitted w-100" href="drop_off_details.html">Drop Request Submitted</a>';}
    //     html = html + requestButton +'</div></div></div></div></div>';
    //     console.log(value.boat_name,value.parking_location.address);
    //     // alert(value.picturePath);
    //     // alert(html);
    //     $('#apiResponse').append(html);

    // });
}

function loadAdminPageStatic(response)
{
    console.log(response);
    //$("#apiResponse").html(response);

    var json = JSON.parse(response);

    console.log(json);

    $.each(json.documents,function(key, value){
        // console.log(key, value)
        var html ='<div class="col-12"><div class="card"><div class="row g_14 mb_14"><div class="col-4"><a class="d-block position-relative rounded_6 overflow-hidden h-100" href="#"><div class="position-absolute top-0 pt-1 ps-1"><span class="badge badge-dark bg-dark fs_10 rounded-pill c_yellow">Active Ride</span></div>';
        html +='<img class="card_img img-fluid w-100 h-100" src="'+value.image_url+'" alt=""></a></div><div class="col-8"><div class="row row_xsmRev g-1"><div class="col-6"><h6 class="fs_14 lh_121 fw-medium mb_6">'+value.boat_name+'</h6><div class="fs_12 mb_12"><a class="text-decoration-none c_primary" href="#">Owner : John Nelson </a></div></div>';
        html +='<div class="col-6 text-end"><div class="badge bg_orange fs_10 rounded-pill"> '+value.parking_location.dock+', '+value.parking_location.zone+'</div></div></div><ul class="card_info"><li><i class="fi fi-rr-marker"></i> Pickup Point : Shuttle Club point 1 </li><li><i class="fi fi-rr-calendar-days"></i> Date : Saturday, July 10, 2024</li><li><i class="fi fi-rr-clock-five"></i> Time : 12.00 PM </li></ul></div></div>';
        html = html + '<div class="pt-2 border-top"><div class="row g-2"><div class="col-6 border-end"><button class="btn btn_sm fw-medium w-100 c_gray">DECLINE</button></div><div class="col-6"><a class="btn btn_sm fw-medium w-100" href="admin.html?boat_number='+value.boat_number+'">ACCEPT DROP OFF</a></div></div></div></div></div>';
        
        console.log(value.boat_name,value.parking_location.dock,value.parking_location.zone);
        // alert(value.picturePath);
        // alert(html);
        $('#apiResponse').append(html);

    });
}


// function acceptDropOff(boat_number)
// {
//     console.log(boat_number);

//     $.ajax({
//         url: "https://us-east-2.aws.data.mongodb-api.com/app/data-dwyeq/endpoint/data/v1/action/updateOne",
//         headers: {
//             'api-key': 'G1HLYwNa0jWevlzpenxkXMGAS79NUsMN5NmIYi7vqA4NP7pxSfFTZiEPBqeZKtGO',
//             'Access-Control-Request-Headers': '*',
//             'User-Agent': 'PostmanRuntime/7.28.4',
//             'Accept': '*/*',
//         },
//         contentType: "application/json",
//         method: "POST",
//         data: {
//             "dataSource": "BoatCluster",
//             "database": "BoatDB",
//             "collection": "Requests",
//             "filter": { "boat_number": boat_number },
//             "update": { "$set": { "status": "drop_confirmed" } }
//         },
//         dataType: "json",
//         success: function(response) {
//             //$("apiResponse").html(response);
//             console.log(response);
//         }
//     });
    
// }

function dropRequestSuccess(data)
{
    $("#request_successModal").modal("show");
}








