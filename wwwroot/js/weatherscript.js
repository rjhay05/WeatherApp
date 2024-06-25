$(document).ready(function () {
    $('#weather-form').submit(function (e) {
        e.preventDefault();
        const responseType = $('#weather-form input[type="radio"]:checked').val();
        const city = $('#weather-form input[type="search"]').val();
        const formData = [responseType, city];

        $.ajax({
            url: 'get-weather',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (result, status, xhr) {
                let main;
                let description;
                let temp;
                let humidity;

                const jsonString = JSON.stringify(result, null, 2)
                    
                if (responseType == "xml") {
                    main = result.weather.value;
                    temp = result.temperature.value;
                    humidity = result.humidity.value;
                    description = result.clouds.name;
                    var x2js = new X2JS();
                    var xmlStr = x2js.json2xml_str(result);
                    $('.snippet').text(xmlStr);
                } else {
                    main = result.weather[0].main;
                    description = result.weather[0].description;
                    temp = result.main.temp
                    humidity = result.main.humidity;
                    $('.snippet').text(jsonString);
                }
                $('#title').text(main);
                $('#sub-title').text(`${temp}°F, ${humidity}% Humidity`);
                $('#description').text(description);
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
    
        $(this).text('Copied!');
        setTimeout(function () {
            $('.copy-button').text('Copy');
        }, 2000);
    });
});


