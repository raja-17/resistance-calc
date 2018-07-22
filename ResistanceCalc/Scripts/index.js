(function () {
    
    $(document).ready(function () {
        //attach a event handler for submit
        $('#formCalc').on('submit', OnSubmit);

        //convert dropdowns
        $('.chosen-select').chosen();
    })

    function OnSubmit(e) {
        e.preventDefault();

        $('#dvError').fadeOut();
        $("#spnCalcValue").remove();
        $("#spnErrorMessage").remove();

        //get colors
        var bandA = $("#ddBandA").val();
        var bandB = $("#ddBandB").val();
        var bandC = $("#ddBandC").val();
        var bandD = $("#ddBandD").val();

        if (bandA !== "" && bandB !== "" && bandC !== "" && bandD !== "") {
            //prepare data
            var postBody = JSON.stringify({ BandAColor: bandA, BandBColor: bandB, BandCColor: bandC, BandDColor: bandD, '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() });

            //call server
            var promise = $.ajax({
                url: $(this).attr('action'),
                type:'POST',
                dataType: 'json',
                data: postBody,
                contentType: 'application/json; charset=utf-8',
                beforeSend: function () {
                    $('#btnCalculate').prop('disabled', 'disabled');
                }
            })

            promise.always(AfterProcess)
            promise.done(OnSuccess);
            promise.fail(OnFailure);
        }       
    }

    function OnSuccess(data) {
        if (data.IsError) ErrorMessage(data.ErrorMessage);
        else
            $('#dvCalcVal').append('<span id="spnCalcValue"><strong>Ohm value: ' + data.OhmValue + ' &ohm;<strong></span>')
    }

    function OnFailure(data) {
        ErrorMessage('UnexpectedError')
    }

    function AfterProcess() {
        $('#btnCalculate').removeProp('disabled');
    }

    function ErrorMessage(message) {
        $('#dvError').append('<span id="spnErrorMessage"><strong>ERROR: </strong> ' + message + '</span>');
        $('#dvError').fadeIn();
    }


})($);