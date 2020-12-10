/* Add here all your JS customizations */

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
        $(".chk:checked").each(function () {
            $("#tutar").show();
            tutar = 0;
            topla += parseFloat($(this).attr("no") / 365);
         
        });
        tutar = (topla * tarihFarki).toFixed(2);

        $("#tutar1").html(tutar + "₺");
        // var aciklama ="("+ d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar tutarı " + tutar + "₺'dir.)";

        // alert(d.getMonth());

        bakiye = $("#deneme").attr("no").toString();
        bakiye = parseFloat(bakiye.replace(/,/g, '.'));
       // bakiye = 637.5;
        var aciklama = "";
        var lastDayOfNextMonth = new Date(today.getFullYear(), today.getMonth() + 2, 0);
        var sonrakiAyTutari = (topla * lastDayOfNextMonth.getDate()).toFixed(2);
       
        if (bakiye >= tutar && tutar!=0) {

            aciklama = "Belirttiğiniz seçeneklere göre " + d.getDate() + "." + (d.getMonth() + 1) + "." + d.getFullYear() + " tarihinden " + lastDayOfMonth.getDate() + "." + (lastDayOfMonth.getMonth() + 1) + "." + lastDayOfMonth.getFullYear() + " tarihine kadar kullanabilirsiniz." +
                " <br> Bir sonraki ay programı kullanmaya devam etmek için en az " + sonrakiAyTutari + "₺ ödeme yapmanız gerekir.";

        } 
       
        else {
            if(bakiye==0 || bakiye<tutar)
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
            $("#modalPayment").html("Ödenecek Tutar:" + tutar +"₺ <br>Belirttiğiniz seçeneklere göre ödeme yapmak istediğinizden emin misiniz?");
        }
    });

   
    function myfunc() {
       
        if (bakiye >= tutar && tutar!=0) {
          
            bakiye = bakiye - tutar;
            window.location.href = "/Home/guncelleBakiye?bakiye="+bakiye;
            $("#tutar").hide();
            $(".chk:checked").each(function () {
                $(this).prop("checked", false);
            });
        }
    }




  


   




