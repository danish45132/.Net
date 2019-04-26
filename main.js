function ac() {

    var fname = document.forms["Registration"]["First_Name"];
    var mname = document.forms["Registration"]["Middle_Name"];
    var lname = document.forms["Registration"]["Last_Name"];
    var email = document.forms["Registration"]["Email_address"];
    var phone = document.forms["Registration"]["Phone_Number"];
    var NID = document.forms["Registration"]["National_ID"];
    var Address = document.forms["Registration"]["Address"];
    var purpose = document.forms["Registration"]["purpose"];
    var SSN = document.forms["Registration"]["Social Security Number"];
    var passport = document.forms["Registration"]["passportMain"];
    var pass = document.forms["Registration"]["passportMatch"];

    //var password = document.forms["RegForm"]["Create password"];  

    //var matchpass = document.forms["RegForm"]["Repeat password"];  
    var d = new Date();
   
    if (fname.value == "") {

        window.alert("Please enter your name.");

        fname.focus();

        return false;

    }




    if (email.value == "") {

        window.alert("Please enter a valid e-mail address.");

        email.focus();

        return false;

    }


    if (email.value.indexOf("@", 0) < 0) {

        window.alert("Please enter a valid e-mail address.");

        email.focus();

        return false;

    }


    if (email.value.indexOf(".", 0) < 0) {

        window.alert("Please enter a valid e-mail address.");

        email.focus();

        return false;

    }


    if (!phone.match(/^\d+$/)) {


        window.alert("Only 10 digits are allowed");

        phone.focus();

        return false;

    }

    if (phone.value == "") {

        window.alert("Please fill your phone number");

        phone.focus();

        return false;

    }

    if (Address.value == "") {

        window.alert("Empty address");

        phone.focus();

        return false

    }

    if (!NID.match(/^\d+$/)) {

        window.alert("Invalid ID");

        phone.focus();

        return false

    }
    //if (!passport.match(/[a-zA-Z]{2}[0-9]{7}/)) {
    //    window.alert("Invalid Format");
    //    passport.focus();
    //    return false;
    //}
    if (passport.value != pass) {
        window.alert("Passport Number Mismatch");
        passport.focus();
        return false;
    }
    if (passport.value == "") {
        window.alert("Empty Passport block");
        passport.focus();
        return false;
    }
    if (purpose.value == "") {
        window.alert("Empty address");

        purpose.focus();

        return false
    }


    if (!SSN.match(/^\d+/)) {

        window.alert("Invalid SSN number");

        SSN.focus();

        return false

    }

    if (SSN.value == "") {

        window.alert("Empty address");

        SSN.focus();

        return false

    }


    return true;

}

$("#picker").on('change', function () {
    if ($(this).find('option:selected').text() == "No") {
        $("#btn-minor_cert").attr('disabled', true)
        $("#btn-pass").attr('disabled', true)
        $("#LOA").attr('disabled', true)
        $("#btn-visa").attr('disabled', true)
        $("#IDL").attr('disabled',false)
    }
    else {
        $("#btn-minor_cert").attr('disabled', false)
        $("#btn-pass").attr('disabled', false)
        $("#LOA").attr('disabled', false)
        $("#btn-visa").attr('disabled', false)
        $("#IDL").attr('disabled', true)
    }
});

$('#picker').on('change', function () {
    if ($(this).find('option:selected').text() === "No") {
        $('#Marriage_certificate').attr('disabled', false)
    }
    else
        $('#Marriage_certificate').attr('disabled', true)
});


$("#Earlier_visa").on('change', function () {

    if ($(this).find('option:selected').text() == "No")
        $("#UKVisa").attr('disabled', true)
    else
        $("#UKVisa").attr('disabled', false)
});

$(document).ready(function () {
    $("#destination_country1").change(function () {
        var val = $(this).val();
        if (val == "usa") {
            $("#visa_type").html("<option value='1'>Student</option><option value='2'>Business</option><option value='3'>Employment</option><option value='4'>Tourist</option>");
        } else if (val == "uk") {
            $("#visa_type").html("<option value='1'>Student</option><option value='2'>Business</option><option value='4'>Tourist</option>");
        } else if (val == "china") {
            $("#visa_type").html("<option value='1'>Student</option><option value='4'>Tourist</option>");
        } else if (val == "germany") {
            $("#visa_type").html("<option value='4'>Tourist</option><option value='3'>Employment</option><option value='3'>Business</option>");
        } else if (val == "france") {
            $("#visa_type").html("<option value='3'>Employment</option><option value='1'>Student</option><option value='4'>Tourist</option>");
        }
        else if (val == "india") {
            $("#visa_type").html("<option value='5'>Medical</option><option value='1'>Student</option><option value='4'>Tourist</option>");
        }
    });
});


$('#destination_country1').on('change click', function () {
    if (this.value == 'usa') {
        $('#uk').hide();
        $('#china').hide();
        $('#france').hide();
        $('#germany').hide();
        $('#india').hide();
        $('#' + this.value).show();
    }
    else if (this.value == 'uk') {
        $('#usa').hide();
        $('#china').hide();
        $('#france').hide();
        $('#germany').hide();
        $('#india').hide();
        $('#' + this.value).show();
    }
    else if (this.value == 'china') {
        $('#uk').hide();
        $('#usa').hide();
        $('#france').hide();
        $('#germany').hide();
        $('#india').hide();
        $('#' + this.value).show();
    }
    else if (this.value == 'germany') {
        $('#uk').hide();
        $('#china').hide();
        $('#france').hide();
        $('#usa').hide();
        $('#india').hide();
        $('#' + this.value).show();
    }
    else if (this.value == 'france') {
        $('#uk').hide();
        $('#china').hide();
        $('#usa').hide();
        $('#germany').hide();
        $('#india').hide();
        $('#' + this.value).show();
    }
    else if (this.value == 'india') {
        $('#uk').hide();
        $('#china').hide();
        $('#usa').hide();
        $('#germany').hide();
        $('#france').hide();
        $('#' + this.value).show();
    }
});


var lastcheckcountry;
$('#origin_country1').change(function () {
    var dropdownval = $(this).val();
    if (lastcheckcountry != dropdownval) {
        $('#destination_country1').not(this).find('option[value="' + lastcheckcountry + '"]').show();
        $('#destination_country1').not(this).find('option[value="' + dropdownval + '"]').hide();
        lastcheckcountry = dropdownval;
    }
});

$('#ChVisa').on('change', function () {
    if ($(this).find('option:selected').text() === "No") {
        $('#btncv').attr('disabled', true)
    }
    else
        $('#btncv').attr('disabled', false)
});

