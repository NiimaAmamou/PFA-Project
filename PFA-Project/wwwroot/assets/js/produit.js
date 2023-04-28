namespace PFA_Project.wwwroot.assets.js {
    function result() {
        let libelle = document.getElementById('libelle').value;
        let pu = document.getElementById('pu').value;
        let img = document.getElementById('img').value;
        let article = document.getElementById('article').value;
        let famille = document.getElementById('famille').value;
        let qte = document.getElementById('qte').value;
        sessionStorage.setItem('libelle', libelle);
        sessionStorage.setItem('pu', pu);
        sessionStorage.setItem('img', img);
        sessionStorage.setItem('article', article);
        sessionStorage.setItem('famille', famille);
        sessionStorage.setItem('qte', qte);

    }
    let getLibelle = document.getElementById('libelle').value = sessionStorage.getItem('libelle');
    let getPu = document.getElementById('pu').value = sessionStorage.getItem('pu');
    let getImg = document.getElementById('img').value = sessionStorage.getItem('img');
    let getArticle = document.getElementById('article').value = sessionStorage.getItem('article');
    let getFamille = document.getElementById('famille').value = sessionStorage.getItem('famille');
    let getQte = document.getElementById('qte').value = sessionStorage.getItem('qte');
}
