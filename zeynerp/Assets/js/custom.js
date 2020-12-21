/* Add here all your JS customizations */

function getSelected() {
    var sList = "";
    $('input[type=checkbox]').each(function () {
        if (this.checked) {
            sList += this.value + ", ";

        }
    });
    $("#CompanyKind").val(sList);
}

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

    var selected;
    selected = chkArray.join(',') + ",";

    if (selected.length > 1) {
    } else {
        alert("Lütfen onay kutusundan en az bir tanesini seçiniz.");
    }
}

var tutar = 0;
var bakiye = 0;
$(".chk").change(function () {
    getValueUsingClass();
    var topla = 0;
    var today = new Date();
    var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth() + 1, 0);
    var d = new Date();
    var tarihFarki = lastDayOfMonth.getDate() - d.getDate() + 1;

    $("#odemeYap").html(tutar + "₺");
    $(".chk:checked").each(function () {
        if (this.disabled == false) {
            $("#tutar").show();
            tutar = 0;
            topla += parseFloat($(this).attr("no") / 365);
        }
    });
    tutar = (topla * tarihFarki).toFixed(2);

    $("#tutar1").html(tutar + "₺");

    $("#odemeYap").html(tutar + "₺" + "<br> Ödeme Yap");
    
    bakiye = $("#bakiyem").text();
    bakiye = parseFloat(bakiye);
   
    var aciklama = "";
    var lastDayOfNextMonth = new Date(today.getFullYear(), today.getMonth() + 2, 0);
    var sonrakiAyTutari = (topla * lastDayOfNextMonth.getDate()).toFixed(2);

    if (bakiye >= tutar && tutar != 0) {

        aciklama = "Belirttiğiniz seçeneklere göre " + d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar kullanabilirsiniz." +
            " <br> Bir sonraki ay programı kullanmaya devam etmek için en az " + sonrakiAyTutari + "₺ ödeme yapmanız gerekir.";
    }
    else {
        if (bakiye == 0 || bakiye < tutar)
            aciklama = "Bakiyeniz yetersiz olduğu için işleminiz gerçekleştirilemedi.";
    }
    $("#tutar1").html(tutar + "₺");
    $("#aciklama").html(aciklama);
    if (tutar == 0) {
        $("#aciklama").html("");
    }

});
$('#odemeYap').click(function () {

    if (bakiye >= 0 && tutar == 0) {

        $("#modalPayment").html("Ödeme yapmak için en az bir modül seçiniz.");
    }
    else if (bakiye < tutar) {
        $("#modalPayment").html("Bakiyeniz yetersiz olduğu için işleminiz gerçekleştirilemedi.");

    }
    else {

        $("#modalPayment").html("Bakiyenizden Düşülecek Tutar:" + tutar + "₺ <br>Belirttiğiniz seçeneklere göre ödeme yapmak istediğinizden emin misiniz?");
    }
});

$("#confirm").click(function () {
    if (bakiye >= tutar && tutar != 0) {
        bakiye = bakiye - tutar;
        var url = "/Home/guncelleBakiye";
        $.get(url, { bakiye: bakiye }, function (data) {


            $("#bakiyem").text(data);

            $("#odemeYap").html("0.00" + "₺" + "<br> Ödeme Yap");

            $(".chk:checked").each(function () {
                this.disabled = true;

            });

            $("#tutar").hide();
        });
    }
});

var ctr = 1;
$('#myTable').on('click', '#satirekle', function () {
    ctr++;
    var numara = "numara" + ctr;
    var secim = "secim" + ctr;
    var txtName = "txtName" + ctr;
    var txtAge = "txtAge" + ctr;
    var txtGender = "txtGender" + ctr;
    var txtOccupation = "txtOccupation" + ctr;
    var txtdeneme = "txtdeneme" + ctr;
    var newTr = '<tr><td id=' + numara + '></td><td><input type="text" id=' + txtName + ' class="form-control"/></td><td><input type="text" id=' + txtAge + ' class="form-control" /></td><td><input type="text" id=' + txtGender + ' class="form-control" /></td><td><input type="text" id=' + txtOccupation + ' class="form-control" /></td><td><input type="text" id=' + txtdeneme + ' class="form-control" /></td><td> <select id=' + secim + 'class="form-control" ><option>Aktif</option><option>Pasif</option></select></td></tr>';
    $('#myTable').append(newTr);
});

var ctr1 = 1;
$('#myTable1').on('click', '#satirekleAdr', function () {
    ctr1++;
    var numaraA = "numaraA" + ctr1;
    var denemeA = "denemeA" + ctr1;
    var txtNameA = "txtNameA" + ctr1;
    var txtAgeA = "txtAgeA" + ctr1;
    var newTr = '<tr><td id=' + numaraA + '></td><td><input type="text" id=' + txtNameA + ' class="form-control"/></td><td><input type="text" id=' + txtAgeA + ' class="form-control" /></td><td id=' + denemeA + '></td></tr>';
    $('#myTable1').append(newTr);
});

$('#yetkiliKaydet').click(function () {
    var values = [];

    $('#myTable > tbody > tr').each(function () {
     
        $(this).find("input").each(function () {
            values.push($(this).val());
        });
        values.push($(this).find('td:last > select').children('option:selected').val());
    });
    for (var i = 0; i < values.length; i++) {
        alert(values[i]);
    }
   
});

               


