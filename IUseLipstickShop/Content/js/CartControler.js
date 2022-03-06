
class CartController {

    constructor() {
        this.renderCartsContent();
        this.allPrice();
        $('.change-price').on('change', function () {
            
            /*$(`.total-price-${Id}-${Colour}-${Size}`).html(Quanity * response.Price)*/
            var click = $(this);
            var Quanity= click.val();
            var Id= click.data('id');
            var Size= click.data('s');
            var Colour = click.data('cl');            
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            if (Carts.length > 0) {
                for (var i = 0; i < Carts.length; i++) {
                    
                    if (Carts[i].Size == "1") {
                        Carts[i].Size = "36"
                    }
                    if (Carts[i].Size == "2") {
                        Carts[i].Size = "38"
                    }
                    if (Carts[i].Size == "3") {
                        Carts[i].Size = "40"
                    }
                    if (Carts[i].Size == "4") {
                        Carts[i].Size = "42"
                    }
                    if (Carts[i].Colour == "1") {
                        Carts[i].Colour = "Green";
                    }
                    if (Carts[i].Colour == "2") {
                        Carts[i].Colour = "Brown";
                    }
                    if (Carts[i].Colour == "3") {
                        Carts[i].Colour = "Orange";
                    }
                    if (Id == Carts[i].Id && Size == Carts[i].Size && Colour == Carts[i].Colour) {
                        Carts[i].Quanity = Quanity;
                        Carts[i].QuanityPice = Carts[i].Quanity * Carts[i].Price
                        $(`.total-price-${Id}-${Colour}-${Size}`).html(Carts[i].QuanityPice)
                        
                        localStorage.setItem('Carts', JSON.stringify(Carts));
                    }
                }
                var tongtien = 0;
                for (var i = 0; i < Carts.length; i++) {
                    tongtien = tongtien + Carts[i].QuanityPice;
                }
                localStorage.setItem('TT', tongtien)
                localStorage.setItem('Carts', JSON.stringify(Carts));
                let TT = localStorage.getItem('TT')
                $('.total-checkout').html(tongtien)
                localStorage.setItem('Carts', JSON.stringify(Carts));
            }
            
        });
        $('.button_add_to_cart').on('click', function () {
            console.log("ok");
            var click = $(this);
            var id = click.data('id');
            var size = $('#isize').val();
            var colour = $('#icolour').val();
            var price = $('#iprice').data('id');
            var img = $('#iimg').data('id');
            var name = $('#iimg').data('n');
            var QuanityPice = price;
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            var a = 0;
            if (Carts.length > 0) {
                for (var i = 0; i < Carts.length; i++) {
                    if (id === Carts[i].Id && size === Carts[i].Size && colour === Carts[i].Colour) {
                        Carts[i].Quanity = Carts[i].Quanity + 1;
                        Carts[i].QuanityPice = Carts[i].QuanityPice + Carts[i].Price
                        a = 1;
                    }
                }
                if (a == 0) {
                    Carts.push({
                        Id: id,
                        Size: size,
                        Colour: colour,
                        Quanity: 1,
                        Img: img,
                        Price: price,
                        Name: name,
                        QuanityPice: QuanityPice
                    });
                }
            }
            else {
                Carts.push({
                    Id: id,
                    Size: size,
                    Colour: colour,
                    Quanity: 1,
                    Img: img,
                    Price: price,
                    Name: name,
                    QuanityPice: QuanityPice
                });
            }
            localStorage.setItem('Carts', JSON.stringify(Carts));
            var tongtien = 0;
            for (var i = 0; i < Carts.length; i++) {
                tongtien = tongtien + Carts[i].QuanityPice;
            }
            localStorage.setItem('TT', tongtien)
            localStorage.setItem('Carts', JSON.stringify(Carts));
            let TT = localStorage.getItem('TT')
            $('.total-checkout').html(TT);
            window.location.href = "/Carts";
            
        });
        $('.checkout').off('click').on('click', function () {
            if (localStorage) {
                var cartsDataAsJson = localStorage.getItem("Carts")
                if (cartsDataAsJson) {
                    /**
                     * @type{ {
                     *  Size: string;
                     *  Colour: string;
                     *  Img: string;
                     *  
                     * }[]}
                    * */
                    var Carts =[];
                    var carts = JSON.parse(cartsDataAsJson);
                    var rows = "";
                    for (var i = 0; i < carts.length; i++) {
                        var cart = carts[i];
                        Carts.push(cart);
                    }
                }
                $.ajax({
                    url: "/Carts/Checkout",
                    data: { cartUser: JSON.stringify(Carts) },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.totalCheck > 0) {
                            $('.total-checkout').html(response.totalCheck)
                        }
                    }
                })
            }
        });
        $('.make-order').off('click').on('click', function () {
            if (localStorage) {
                var cartsDataAsJson = localStorage.getItem("Carts")
                var TT = localStorage.getItem('TT')
                $('.all-money').html(TT);
                if (TT > 0) {
                    window.location.href = "/Order/Index";
                }
                else {
                    alert("Gio hang dang ko co gi ! ");
                }
            }
        });
        $('.done').off('click').on('click', function () {
            var AllPrice = $('.all-money').val();
            var AddRess = $('.Address').val();
            var Phone = $('.Phone').val();
            var TT = localStorage.getItem('TT')
            if (AddRess == "") {
                alert("Nhap lai dia chi !");
            }
            else if (Phone == "") {
                alert("Nhap lai so dien thoai !");
            }
            else {
                if (localStorage) {
                    var cartsDataAsJson = localStorage.getItem("Carts")
                    if (cartsDataAsJson) {
                        /**
                         * @type{ {
                         *  Size: string;
                         *  Colour: string;
                         *  Img: string;
                         *  
                         * }[]}
                        * */
                        var Carts = [];
                        var carts = JSON.parse(cartsDataAsJson);
                        var rows = "";
                        for (var i = 0; i < carts.length; i++) {
                            var cart = carts[i];
                            Carts.push(cart);
                        }
                    }
                    $.ajax({
                        url: "/Order/MakeOrder",
                        data: { cartUser: JSON.stringify(Carts), addRess: AddRess, phone: Phone },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status == true) {
                                Carts = [];
                                localStorage.setItem('Carts', JSON.stringify(Carts));
                                localStorage.setItem('TT', 0);
                                alert("XONG!");
                                window.location.href = "/Events/Index";
                            }
                        }
                    })
                }
            }
        });
        $('.button_remove').off('click').on('click', function () {
            var rows = "";
            var click = $(this);
            var Id = click.data('id');
            var Size = click.data('s');
            var Colour = click.data('cl');
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            if (Carts.length > 0) {
                for (var i = 0; i < Carts.length; i++) {
                    if (Carts[i].Size == "1") {
                        Carts[i].Size = "36"
                    }
                    if (Carts[i].Size == "2") {
                        Carts[i].Size = "38"
                    }
                    if (Carts[i].Size == "3") {
                        Carts[i].Size = "40"
                    }
                    if (Carts[i].Size == "4") {
                        Carts[i].Size = "42"
                    }
                    if (Carts[i].Colour == "1") {
                        Carts[i].Colour = "Green";
                    }
                    if (Carts[i].Colour == "2") {
                        Carts[i].Colour = "Brown";
                    }
                    if (Carts[i].Colour == "3") {
                        Carts[i].Colour = "Orange";
                    }
                    if (Id == Carts[i].Id && Size == Carts[i].Size && Colour == Carts[i].Colour) {
                        var tongtien = localStorage.getItem('TT');
                        let TT = tongtien - Carts[i].QuanityPice;
                        localStorage.setItem('TT', TT)
                        var tmp = Carts[i]
                        Carts[i] = Carts[0]
                        Carts[0] = tmp
                        Carts.splice(0, 1);
                        localStorage.setItem('Carts', JSON.stringify(Carts));
                        if (localStorage) {
                            var cartsDataAsJson = localStorage.getItem("Carts")
                            if (cartsDataAsJson) {
                                /**
                                 * @type{ {
                                 *  Size: string;
                                 *  Colour: string;
                                 *  Img: string;
                                 *  
                                 * }[]}
                                 * */
                                var carts = JSON.parse(cartsDataAsJson);

                                for (var i = 0; i < carts.length; i++) {
                                    var cart = carts[i];
                                    if (cart.Size == "1") {
                                        cart.Size = "36"
                                    }
                                    if (cart.Size == "2") {
                                        cart.Size = "38"
                                    }
                                    if (cart.Size == "3") {
                                        cart.Size = "40"
                                    }
                                    if (cart.Size == "4") {
                                        cart.Size = "42"
                                    }
                                    if (cart.Colour == "1") {
                                        cart.Colour = "Green";
                                    }
                                    if (cart.Colour == "2") {
                                        cart.Colour = "Brown";
                                    }
                                    if (cart.Colour == "3") {
                                        cart.Colour = "Orange";
                                    }
                                        rows += `<tr>
                                            <td class="PRODUCT">
                                                <img style="height: 200px;float: left; margin-top: 5px;" src="/Content/img/${cart.Img}">
                                                <div class="thongtin">
                                                    <h3>${cart.Name}</h3>
                                                    Size: ${cart.Size}
                                                    <br>
                                                    Color: ${cart.Colour}
                                                    <br>
                                                    <a style="margin-left: 15px; color: pink" class="button_remove" data-id="${cart.Id}" data-s="${cart.Size}" data-cl="${cart.Colour}">Remove</a>
                                                </div>
                                            </td>

                                            <td class="PRICE">
                                                <h4>€${cart.Price}</h4>
                                            </td>
                                            <td class="QUANTITY">
                                                <input class="change-price" data-id="${cart.Id}" data-s="${cart.Size}" data-cl="${cart.Colour}" value="${cart.Quanity}" type="number" min="1" max="10">
                                            </td>

                                            <td class="TOTAL">
                                                €<h4 style="float:right" class="total-price-${cart.Id}-${cart.Colour}-${cart.Size}">${cart.QuanityPice}</h4>
                                            </td>
                                        </tr>
                                        `
                                }
                                $('.js__cart-content').html(rows);
                            }
                        }
                    }
                }
            }
            if (Carts.length == 0) {
                $('.total-checkout').html("0");
            }
            if (Carts.length>0) {
                
                new CartController()
            }
        });
    }

    allPrice() {
        var TT = localStorage.getItem('TT')
        $('.all-money').html(TT);
        $('.total-checkout').html(TT);
    }
    renderCartsContent() {
        if (localStorage) {
            var cartsDataAsJson = localStorage.getItem("Carts")
            if (cartsDataAsJson) {
                /**
                 * @type{ {
                 *  Size: string;
                 *  Colour: string;
                 *  Img: string;
                 *  
                 * }[]}
                 * */
                var carts = JSON.parse(cartsDataAsJson);
                var rows = "";
                for (var i = 0; i < carts.length; i++) {
                    var cart = carts[i];
                    if (cart.Size == "1") {
                        cart.Size = "36"
                    }
                    if (cart.Size == "2") {
                        cart.Size = "38"
                    }
                    if (cart.Size == "3") {
                        cart.Size = "40"
                    }
                    if (cart.Size == "4") {
                        cart.Size = "42"
                    }
                    if (cart.Colour == "1") {
                        cart.Colour = "Green";
                    }
                    if (cart.Colour == "2") {
                        cart.Colour = "Brown";
                    }
                    if (cart.Colour == "3") {
                        cart.Colour = "Orange";
                    }
                    rows += `<tr>
                            <td class="PRODUCT">
                                <img style="height: 200px;float: left; margin-top: 5px;" src="/Content/img/${cart.Img}">
                                <div class="thongtin">
                                    <h3>${cart.Name}</h3>
                                    Size: ${cart.Size}
                                    <br>
                                    Color: ${cart.Colour}
                                    <br>
                                    <a style="margin-left: 15px; color: red" class="button_remove" data-id="${cart.Id}" data-s="${cart.Size}" data-cl="${cart.Colour}">Remove</a>
                                </div>
                            </td>

                            <td class="PRICE">
                                <h4>€${cart.Price}</h4>
                            </td>
                            <td class="QUANTITY">
                                <input class="change-price" data-id="${cart.Id}" data-s="${cart.Size}" data-cl="${cart.Colour}" value="${cart.Quanity}" type="number" min="1" max="10">
                            </td>

                            <td class="TOTAL">
                                €<h4 style="float:right" class="total-price-${cart.Id}-${cart.Colour}-${cart.Size}">${cart.QuanityPice}</h4>
                            </td>
                        </tr>
`
                }
                $('.js__cart-content').html(rows);
            }
        }
        
    }
}
new CartController();
