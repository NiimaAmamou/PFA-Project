let articles = [];

    function Create() {
    var article = document.getElementById("id_article");
    var articleid = article.value;
    var prixarticle = document.getElementById("pu").value;
    var articlelibelle = article.options[article.selectedIndex].text;
    var quantiteart = document.getElementById("quantite").value;
    var newArticle = {
        id_article: articleid,
        prixunitaire: prixarticle,
        lib_article: articlelibelle,
        quantite: quantiteart,
        };
    articles.push(newArticle);
    console.log(articles);
    Read();
    }

    function Read() {
        var data = '';
    for (var i = 0; i < articles.length; i++) {
        data += '<tr>';
        data += '<td> ' + articles[i].lib_article + '<input type="hidden" value="' + articles[i].id_article+ '" name="id_articles" /></td>';
        data += '<td> ' + articles[i].prixunitaire + '</td > ';
        data += '<td>' + articles[i].quantite + '<input type="hidden" value="' + articles[i].quantite+ '" name="quantites" /></td>';
        data += '<td><button class="btn btn-primary btn-rounded btn-fw" onclick="SupprimerArticle(' + i + ')">Delete</button></td>';
    data += '</tr>';
        }
document.getElementById("content").innerHTML = data;
    }

function SupprimerArticle(item) {
    articles.splice(item, 1);
    Read();
}
function fun() {
    document.getElementById("myForm").reset();
}   
 