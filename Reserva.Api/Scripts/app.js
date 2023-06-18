new Vue({
    el: '#app',
    data: {
        message: 'teste',
        produtos:[]
    },
    mounted: function () {
        this.fetchProdutos();        
    },
    methods: {
        fetchProdutos: function () {
            var self = this;

            fetch('Produtos')
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    self.produtos = data;
                })
                .catch(function (error) {
                    console.error(error);
                })
        }

  
    }
});