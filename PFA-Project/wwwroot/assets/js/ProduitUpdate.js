let articles = [];



    function CreateUp() {
    var article = document.getElementById("id_article");
    var articleid = article.value;
   
    var articlelibelle = article.options[article.selectedIndex].text;
    var quantiteart = document.getElementById("quantite").value;
    var newArticle = {
        id_article: articleid,
       
        lib_article: articlelibelle,
        quantite: quantiteart,
        };
    articles.push(newArticle);
    console.log(articles);
    Read();
}
function SupprimerArticleUp(item) {
    articles.splice(item, 1);
    Read();
}


function fun() {
    document.getElementById("myForm").reset();
}   
 