"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Connection established..");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (book) {
    console.log("Book added: " + JSON.stringify(book));
    $("tbody").append(`<tr id="${book.id}">
    <td>
            ${book.title}
    </td>
    <td>
            ${book.author}
    </td>
    <td>
          ${book.language}
    </td>
    <td>
        <a href="/Books/Edit?id=${book.id}">Edit</a> |
        <a href="/Books/Details?id=${book.id}">Details</a> |
        <a href="/Books/Delete?id=${book.id}">Delete</a>
      </td>
    </tr>
    `);
});

connection.on("BookEdited", function (book) {
    console.log("Edited Book Result: " + JSON.stringify(book));
    $(`#${book.id}`)[0].innerHTML = `<tr>
    <td>
            ${book.title}
    </td>
    <td>
            ${book.author}
    </td>
    <td>
          ${book.language}
    </td>
    <td>
        <a href="/Books/Edit?id=${book.id}">Edit</a> |
        <a href="/Books/Details?id=${book.id}">Details</a> |
        <a href="/Books/Delete?id=${book.id}">Delete</a>
      </td>
    </tr>
    `;
});

connection.on("BookRemoved", function (book) {
    console.log("The removed Book was: " + JSON.stringify(book));
    $(`#${book.id}`).remove();
});