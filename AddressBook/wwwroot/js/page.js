$(document).ready(function () {
    //$(':input[type="submit"]').prop('disabled', true);

    let validName = validEmail = validMobile = validLandline = validWebsite = validAddress = false;
    let fullName = $("#NameEntry");
    let emailAddress = $("#EmailEntry");
    let mobileNumber = $("#MobileEntry");
    let landLineNumber = $("#LandlineEntry");
    let website = $("#WebsiteEntry");
    let address = $("#AddressEntry");

    //alert("Hey! I am ready");

    $("#NameEntry").on("input", function () {
        //alert("Hello");
        $.fn.nameValidation();
    });
    $("#EmailEntry").on("input", function () {
        //alert("Hello");
        $.fn.emailValidation();
    });
    $("#MobileEntry").on("input", function () {
        //alert("Hello");
        $.fn.mobileValidation();
    });
    $("#LandlineEntry").on("input", function () {
        //alert("Hello");
        $.fn.landLineValidation();
    });
    $("#WebsiteEntry").on("input", function () {
        //alert("Hello");
        $.fn.websiteValidation();
    });
    $("#AddressEntry").on("input", function () {
        //alert("Hello");
        $.fn.addressValidation();
    });

    $.fn.nameValidation = function () {
        if (!fullName.val()) {
            $("#RequiredName").text("Name is required.");

        }
        else {
            $("#RequiredName").text("*");
            validName = true;
        }
    };

    $.fn.emailValidation = function () {
        /*
        let validEmail = /^[0-9a-z.\s+_]+@@[0-9a-z-.+]+\.[a-z]{2,4}$/;
        
        if(validEmail.test(emailAddress.val())
        {
            $("#RequiredEmail").text("*");
        }
        */
        if (!emailAddress.val()) {
            $("#RequiredEmail").text("Email is required.");

        }

        else {
            $("#RequiredEmail").text("*")
            validEmail = true;
        }
    };
    $.fn.mobileValidation = function () {
        if (!mobileNumber.val()) {
            $("#RequiredMobile").text("Mobile is required.");

        }
        else if (isNaN(mobileNumber.val())) {
            $("#RequiredMobile").text("Mobile is incorrect.");

        }
        else if (mobileNumber.val().toString().length != 10) {
            $("#RequiredMobile").text("Mobile is incorrect.");

        }
        else {
            $("#RequiredMobile").text("*");
            validMobile = true;
        }
    };

    $.fn.landLineValidation = function () {
        if (!landLineNumber.val()) {
            $("#RequiredLandline").text("Landline is required.");

        }
        else if (isNaN(landLineNumber.val())) {
            $("#RequiredLandline").text("Landline is incorrect.");

        }
        else if (landLineNumber.val().toString().length != 10) {
            $("#RequiredLandline").text("Landline is incorrect.");

        }
        else {
            $("#RequiredLandline").text("*");
            validLandline = true;
        }
    };
    $.fn.websiteValidation = function () {

        if (!website.val()) {
            $("#RequiredWebsite").text("Website is required.");

        }

        else {
            $("#RequiredWebsite").text("*");
            validWebsite = true;
        }
    };
    $.fn.addressValidation = function () {

        if (!address.val()) {
            $("#RequiredAddress").text("Address is required.");

        }

        else {
            $("#RequiredAddress").text("*");
            validAddress = true;
        }
    };
    
    $("#SubmitButton").on("click", function (event) {
        $.fn.nameValidation();
        $.fn.emailValidation();
        $.fn.mobileValidation();
        $.fn.landLineValidation();
        $.fn.websiteValidation();
        $.fn.addressValidation();


        if(!validName && !validEmail && !validMobile && !validLandline && !validWebsite && !validAddress)
        {
            alert("Please enter the form correctly!!");
            event.preventDefault();
        }
    });
    $("#EditButton").on("click", function (event) {
        $.fn.nameValidation();
        $.fn.emailValidation();
        $.fn.mobileValidation();
        $.fn.landLineValidation();
        $.fn.websiteValidation();
        $.fn.addressValidation();


        if (!validName && !validEmail && !validMobile && !validLandline && !validWebsite && !validAddress) {
            alert("Please enter the form correctly!!");
            event.preventDefault();
        }
    });
    
    
});