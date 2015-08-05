
//    $(document).ready(function () {
//        $('#mytable').DataTable({
//            responsive: true
//        });
//    });

//    var aar = new Array();
//    var counter = 0;

//function addservicetotable()
//{
//    var b = document.getElementById("quantity").value;
//    var c = document.getElementById("price").value;
//    var a = document.getElementById("title");
//    var d = c * b;
   
//    var obj = new srv(counter++, a, c, b);
//    aar.push(obj);
//    $('#tablerows').append("<tr><td>" + a + "</td><td>" + b + "</td><td>" + c + "</td><td>" + d + "</td><td>" + "<button class='btn btn-danger' onclick=" + "'deletefromarray(" + (counter-1) + ");'>Delete</button>" + "</td></tr>");

//    document.getElementById("quantity").value = "";
//    document.getElementById("price").value = "";
//    return false;
//}


//var srv=function(d,a,b,c)
//{
//    this.serviceid=d;
//    this.id=a;
//    this.price = b;
//    this.quantity = c;
//}

//var quotation= function()
//{
//    this.id;
//    this.date;
//    this.shipperid;
//    this.comodityid;
//    this.quantity;
//    this.packingid;
//    this.weight;
//    this.loadingport;
//    this.dischargeport;
//    this.flightno;
//    this.sailingdate;
//    this.arrivaldate;
//    this.consigneeid;
//    this.status;
//    this.payedamount;
//}

//function sendtoactionmethodforedit()
//{
//    var obj = new quotation();
//    obj.id = document.getElementById("Id").value;
//    obj.date = document.getElementById("Date").value;
//    obj.shipperid = document.getElementById("ShipperId").value;
//    obj.comodityid = document.getElementById("ComodityId").value;
//    obj.quantity = document.getElementById("Quantity").value;
//    obj.packingid = document.getElementById("PackingId").value;
//    obj.weight = document.getElementById("Weight").value;
//    obj.loadingport = document.getElementById("LoadingPort").value;
//    obj.dischargeport = document.getElementById("DischargePort").value;
//    obj.flightno = document.getElementById("FlightNo").value;
//    obj.arrivaldate = document.getElementById("ArrivalDate").value;
//    obj.sailingdate = document.getElementById("SailingDate").value;
//    obj.consigneeid = document.getElementById("ConsigneeId").value;
//    obj.status = document.getElementById("Status").value;
//    obj.payedamount = document.getElementById("PayedAmount").value;

//    $.ajax({
//        url: '/Quotations/EditQuotation',
//        dataType: "json",
//        type: 'POST',
//        data: JSON.stringify({ ar: aar, ob: obj }),
//        contentType: 'application/json',
//        success: function (data) {
//            alert(data);
//            alert("returened.");
//        },
//        error: function (xhr) {
//            alert('error');
//        }
//    });
//}


//function sendtoactionmethod()
//{
//    var obj = new quotation();

//    obj.date = document.getElementById("Date").value;
//    obj.shipperid = document.getElementById("ShipperId").value;
//    obj.comodityid = document.getElementById("ComodityId").value;
//    obj.quantity = document.getElementById("Quantity").value;
//    obj.packingid = document.getElementById("PackingId").value;
//    obj.weight = document.getElementById("Weight").value;
//    obj.arrivaldate = document.getElementById("ArrivalDate").value;
//    obj.loadingport = document.getElementById("LoadingPort").value;
//    obj.dischargeport = document.getElementById("DischargePort").value;
//    obj.flightno = document.getElementById("FlightNo").value;
//    obj.sailingdate = document.getElementById("SailingDate").value;
//    obj.consigneeid = document.getElementById("ConsigneeId").value;

//    $.ajax({
//        url: '/Quotations/AddQuotation',
//        dataType: "json",
//        type: 'POST',
//        data: JSON.stringify({ ar: aar, ob: obj }),
//        contentType: 'application/json',
//        success: function (data) {
//            alert(data);
//            alert("returened.");
//        },
//        error: function (xhr) {
//            alert('error');
//        }
//    });
//}

