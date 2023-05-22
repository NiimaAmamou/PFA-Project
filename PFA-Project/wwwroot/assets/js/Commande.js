let produits = [];
var total = 0.0;
function FindProduit(id) {
    for (var i = 0; i < produits.length; i++) {
        if (produits[i].idproduit == id) {
            return i;
        }
    }
    return -1;
}
function Read() {
    var data = '';
    total = 0;
    for (var i = 0; i < produits.length; i++) {
        total = total + parseInt(produits[i].quantite) * parseFloat(produits[i].prixproduit);
        data += '<input type="hidden" value="' + produits[i].idproduit + '" name="idproduit" />'
        data += ' <li class="woocommerce-mini-cart-item mini_cart_item">';
        data += '<a href="javascript:void(0)" class="remove remove_from_cart_button" onclick="SupprimerProduit(' + i + ')">×</a>';
        data += ' <a href="javascript:void(0)"> <input type = "hidden" value = "' + produits[i].prixproduit + '" name = "prix"/>';
        data += produits[i].libelleproduit + '</a> ';
        data += '   <span class="quantity">' + produits[i].quantite + 'x <input type = "hidden" value = "' + produits[i].quantite + '" name = "quantite"/>';
        data += '<span class="woocommerce-Price-amount amount"> ' + produits[i].prixproduit + ' <span class="woocommerce-Price-currencySymbol"> DH</span ></span > ';
        data += '</span>'
        data += '</li>';
        }
    document.getElementById("contentul").innerHTML = data;
    document.getElementById("total").innerText = total;
    document.getElementById("cpt").innerText = "(" + produits.length + ")";
    }

function CreateProduit(id) {
    var libelleproduit = document.getElementById("libelleproduit_" + id).innerText;
    var prixproduit = document.getElementById("prixproduit_" + id).innerText;
    var qnt = 1;

    var pos = FindProduit(id);
    if (pos == -1) {
        let newProduit = {
            idproduit: id,
            libelleproduit: libelleproduit,
            prixproduit: prixproduit.replace(" DH", ""),
            quantite: qnt,

        };
        produits.push(newProduit);
    }
    else {
        produits[pos].quantite = parseInt(produits[pos].quantite) + qnt;
    }
    document.getElementById("moncard").style.visibility = "visible";
    Read();
}
function SupprimerProduit(item) {
    produits.splice(item, 1);
    //document.getElementById("cpt").innerText = "(" + produits.length + ")";
    if (produits.length == 0) {
        document.getElementById("moncard").style.visibility = "hidden";
        $('.cart-dialog--active').removeClass('cart-dialog--active');
    }
        Read();
    }



  

