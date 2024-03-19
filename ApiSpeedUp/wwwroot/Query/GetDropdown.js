$(document).ready(function () {
    //alert("Ready sir");
    SubsDropDown();

});

function SubsDropDown() {
    

    var settings = {
        "url": "/api/ApiSpeed/GetAllOrg",
        "method": "get",
        "headers": {
            "content-type": "application/json"
        },
        "data": "",
    };
    ShowLoader();
    $.ajax(settings).done(function (response) {
        HideLoader();
        if (response == null) {
            alert('Error');
            return false;
        }
        //console.log(response);

        var list = response;
        if (list.length > 0) {
            $.each(list, function (index, value) {
                {
                    $('#dropdown').append('<option value="' + value.orgname + '">' + value.orgname + '</option>');

                }
            });
        }
    });
}


function getorgcount() {
    var org = $('#dropdown').val();
    var settings = {
        "url": "/api/ApiSpeed/GetCount/"+org,
        "method": "get",
        "headers": {
            "content-type": "application/json"
        },
        "data": "",
    };
    ShowLoader();
    $.ajax(settings).done(function (response) {
        HideLoader();
        if (response == null) {
            alert("Error");
            return false;
        }
        //console.log(response);
        setvaluecount(response);

        
    });

}

function setvaluecount(response) {
    var count = response;
    $('#countorg').val(count);
}


function ShowLoader() {
    $('#loader_main').css('display', 'block');
}

function HideLoader() {
    $('#loader_main').css('display', 'none');
}