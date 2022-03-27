
//empieza el codigo javascript
$(document).ready(function () {
    alert("Hola");
    $('#programa').change(function () {
        var opcionPrograma;
        $('#programa option:selected').each(function () {

            opcionPrograma = $(this).text();
            $('#ponerPrograma').val(opcionPrograma);
        });

        console.log(opcionPrograma);
    });

    

    /*if ($('#tablaCurso').length) {

        $('#intensidad').removeAttr("disabled");
    } else
    {
        alert("Existe tabla");
    }*/
});



