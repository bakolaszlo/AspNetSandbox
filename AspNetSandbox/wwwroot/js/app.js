const app = Vue.createApp({
  data() {
    return {
      bookList: [],
    };
  },
  mounted() {
    this.getBookList();
  },
  methods: {
    log() {
      console.log(this.bookList[1]);
    },
    getBookList() {
      var requestOptions = {
        method: "GET",
        redirect: "follow",
      };

      fetch("https://localhost:5001/api/books", requestOptions)
        .then((response) => {
          this.bookList = response.json();
          console.log(this.bookList[0]);
          console.log(this.bookList, "booklist");
          console.log(response.json());
        })
        .then((result) => console.log(result))
        .catch((error) => console.log("error", error));
    },
  },
});

app.mount("#app");
