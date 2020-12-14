function getSelected() {   //CompanyDetail ve CompanyAdd sayfalarinda checkbox secilmesi ile ilgili islemler
    var sList = "";
    $('input[type=checkbox]').each(function () {
        if (this.checked) {
            sList += this.value + ", ";

        }
    });
    $("#CompanyKind").val(sList);
    alert(sList);
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

    /* virgulle td value degerleri listesi */
    var selected;
    selected = chkArray.join(',') + ",";

    if (selected.length > 1) {
        // alert("Seçtiniz " + selected);
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
    //alert(lastDayOfMonth.getDate());
    var d = new Date();
    //alert(d.getDate());
    var tarihFarki = lastDayOfMonth.getDate() - d.getDate() + 1;
    //alert(tarihFarki);
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
    // var aciklama ="("+ d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar tutarı " + tutar + "₺'dir.)";

    // alert(d.getMonth());

    // bakiye = $("#remainder").attr("data-remainder").toString();
    bakiye = $("#bakiyem").text();
    bakiye = parseFloat(bakiye);
    // bakiye = parseFloat(bakiye.replace(/,/g, '.'));
    // bakiye = 637.5;
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


//function myfunc() {

//    if (bakiye >= tutar && tutar != 0) {

//        bakiye = bakiye - tutar;
//        alert(bakiye);

//        $.ajax({
//            type: "POST",
//            url: '@Url.Action("guncelleBakiye", "Home")',
//            data: {
//                bakiye: bakiye,
//            },
//            dataType: 'json',
//            success: function (result) {
//            }
//        })
//        //window.location.href = "/Home/guncelleBakiye?bakiye=" + bakiye;
//        $("#tutar").hide();

//    }
//}

   

$(function () {
    $("#confirm").click(function () {

        alert("eksilmemiş bakye" + bakiye);
        if (bakiye >= tutar && tutar != 0) {

            bakiye = bakiye - tutar;
            alert(bakiye);
            alert(tutar);
            
            $.ajax({
                type: "POST",
                url: "/Home/guncelleBakiye",
                data: { bakiye: bakiye },
                dataType: "json",
                success: function (result) {
                    //alert(typeof (result.msg));
                    var n = result.msg.toString();

                    $("#bakiyem").text(n);

                    $("#odemeYap").html("0.00" + "₺" + "<br> Ödeme Yap");

                    $(".chk:checked").each(function () {
                        this.disabled = true;

                    });
                },
            });
            //window.location.href = "/Home/guncelleBakiye?bakiye=" + bakiye;
            $("#tutar").hide();

        }

    });

    var ctr = 1;
    $('#myTable').on('click', '#satirekle', function () {
        ctr++;
        var numara = "numara" + ctr;
        //var optA = "optA" + ctr;
        //var optP = "optP" + ctr;
        var secim = "secim" + ctr;
       
        var txtName = "txtName" + ctr;
        var txtAge = "txtAge" + ctr;
        var txtGender = "txtGender" + ctr;
        var txtOccupation = "txtOccupation" + ctr;
        var txtdeneme = "txtdeneme" + ctr;
        var newTr = '<tr><td id=' + numara + '></td><td><input type="text" id=' + txtName + ' class="form-control"/></td><td><input type="text" id=' + txtAge + ' class="form-control" /></td><td><input type="text" id=' + txtGender + ' class="form-control" /></td><td><input type="text" id=' + txtOccupation + ' class="form-control" /></td><td><input type="text" id=' + txtdeneme + ' class="form-control" /></td><td> <select id=' + secim + ' ><option>Aktif</option><option>Pasif</option></select></td></tr>';
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
    //$("#satirekle").click(function (e) {
    //    var table = document.getElementById("myTable");
    //    var row = table.insertRow(0);
    //    var cell1 = row.insertCell(0);
    //    cell1.setAttribute("class", "form-control");
       

    //    //var node = document.createElement("TR");
    //    //node.setAttribute("id", "myTr");
    //    //document.getElementById("myTable").appendChild(node);
    //    //var y = document.createElement("TD");
    //    //document.getElementById("myTr").appendChild(y);
       
    //    //var xTable = document.getElementById('myTable');
    //    //var body = xTable.tBodies[0]
    //    //var rows = body.rows;
        
    //    //// pick the last and prepend
    //    //rows[rows.length - 1].insertAdjacentHTML('afterend', " <tr> <td>1</td> <td><input type='text' placeholder='2016'></td><td><input type='text' placeholder='2016' class='form - control'></td> <td><input type='text' placeholder='2016' class='form - control'></td> <td><input type='text' placeholder='2016' class='form - control'></td> <td><input type='text' placeholder='2016' class='form - control'></td><td><select>< option > Aktif</option ><option>Pasif</option></select ></td>");


    //});
});


//function insert_Row() {
    



//}








