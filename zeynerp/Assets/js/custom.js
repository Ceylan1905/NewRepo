/* Add here all your JS customizations */
function getSelected() {
    var sList = "";
    $('input[type=checkbox]').each(function () {
        if (this.checked) {
            sList += this.value + ", ";

        }
    });
    $("#CompanyKind").val(sList);
    alert(sList);
}


$(document).ready(function () {
    $("#companycheck").click(function () {
        if ($(this).is(":checked")) {
            $("#sirketAdi").hide();
            $("#sirketKimligi").show();
        } else {
            $("#sirketAdi").show();
            $("#sirketKimligi").hide();
        }
    });

    function getValueUsingClass() {
        var chkArray = [];
        / * Bir sınıfın 'chk' ekli tüm onay kutularını ara ve seçili olup olmadıklarını kontrol edin * /
        $(".chk:checked").each(function () {
            chkArray.push($(this).val());
        });

        /* virgulle td value degerleri listesi */
        var selected;
        selected = chkArray.join(',') + ",";

        if (selected.length > 1) {
            // alert("Seçtiniz " + selected);
        } else {
            alert("Lütfen onay kutusundan en az bir tanesini seçiniz.");
        }
    }

    $(".chk").change(function () {
        getValueUsingClass();
        var topla = 0;

        var today = new Date();
        var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth() + 1, 0);
        //alert(lastDayOfMonth.getDate());
        var d = new Date();
        //alert(d.getDate());
        var tarihFarki = lastDayOfMonth.getDate() - d.getDate() + 1;
        //alert(tarihFarki);
        $(".chk:checked").each(function () {
            topla += parseFloat($(this).attr("no") / 365);

        });
        var tutar = (topla * tarihFarki).toFixed(2);

        $("#tutar1").html(tutar + "₺");
        // var aciklama ="("+ d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar tutarı " + tutar + "₺'dir.)";

        // alert(d.getMonth());

        var bakiye = parseFloat($("#deneme").attr("no"));
       
        var aciklama = "";
        var lastDayOfNextMonth = new Date(today.getFullYear(), today.getMonth() + 2, 0);
        var sonrakiAyTutari = (topla * lastDayOfNextMonth.getDate()).toFixed(2);
        if (bakiye >= tutar && tutar!=0) {

            aciklama = "Belirttiğiniz seçeneklere göre " + d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar kullanabilirsiniz." +
                " <br> Bir sonraki ay programı kullanmaya devam etmek için en az " + sonrakiAyTutari + "₺ ödeme yapmanız gerekir.";

        }
        else {
            aciklama = "Bakiyeniz yetersiz olduğu için işleminiz gerçekleştirilemedi.";
        }
        if (tutar == 0) {
            $("#aciklama").html("");
        }
        $("#aciklama").html(aciklama);




    });

    

});