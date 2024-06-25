$(document).ready(function () {
    $('#weather-form').submit(function (e) {
        e.preventDefault();
        var formData = $('#weather-form input').map(function () {
            return $(this).val();
        }).get();
        $.ajax({
            url: 'get-weather',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (result, status, xhr) {
                if ($('#selection-value').val() == "xml") {
                    var x2js = new X2JS();
                    var xmlStr = x2js.json2xml_str(result);
                    $('.snippet').text(xmlStr);
                    return;
                } 
                const jsonString = JSON.stringify(result, null, 2);
                $('.snippet').text(jsonString);
            },
            error: function (error, status, xhr) {
                console.log(error);
            }
        });
    });

    $('.copy-button').click(function () {
        var code = $('.snippet').text();
        var tempInput = $('<input>');
        $('body').append(tempInput);
        tempInput.val(code).select();
        document.execCommand('copy');
        tempInput.remove();
    
        $(this).textContent = 'Copied!';
        setTimeout(function () {
            $(this).textContent = 'Copy';
        }, 2000);
    });

    $('#json-selection').click(function (e) {
        e.preventDefault()
        $('#selection-value').val("json");
    });

    $('#xml-selection').click(function (e) {
        e.preventDefault();
        $('#selection-value').val("xml");
    });
});

function copyCode(button) {
    var code = button.nextElementSibling.innerText;
    navigator.clipboard.writeText(code).then(function () {
        button.textContent = 'Copied!';
        setTimeout(function () {
            button.textContent = 'Copy';
        }, 2000);
    });
}

