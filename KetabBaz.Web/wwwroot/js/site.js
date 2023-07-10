const search = document.querySelector("#navbarSearchInput");
const matchList = document.querySelector("#navbarSearchResult");
let timeout;

const searchBooks = async searchText => {
    clearTimeout(timeout);
    timeout = setTimeout(async () => {
        if (searchText.length < 3) {
            return;
        }
		const response = await fetch(`/api/books?query=${searchText}&pageSize=5`);
        const books = await response.json();

        outputBookListHtml(books, searchText);
    }, 500);
}

const outputBookListHtml = (books, searchText) => {
    let html = "";

    if (books.length > 0) {
		html = books.map(book => `
            <a href="/books/${book.id}" class="list-group-item list-group-item-action p-1">
				<div class="container p-0">
					<div class="row gx-0">
						<div class="col-3">
							<img src=/${book.imageUrl} class="rounded" width="50px" height="70px"/>
						</div>
						<div class="col-9">
							<div class="navbar-search-result-item">
								${book.translatedTitle}
							</div>
							<div class="navbar-search-result-item" style="font-size: 0.9rem;">
								مترجم: ${book.translatorName}
							</div>
							<div class="navbar-search-result-item" style="font-size: 0.8rem;">
								نویسنده: ${book.authorName}
							</div>
						</div>
					</div>
				</div>
			</a>
        `).join("");

		html += `
			<a href="/search?query=${searchText}" class="list-group-item list-group-item-action p-1">
				<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
					<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"/>
				</svg>
				نمایش همه نتایج برای «${searchText}»
			</a>
		`;

    } else {
        html = `
			<div class="list-group-item list-group-item-action p-1">
				جستجو برای عبارت «${searchText}» با هیچ کتابی هم خوانی نداشت.
			</div>
		`;
    }

    matchList.innerHTML = html;
    matchList.style.display = "block";
}

search.addEventListener("input", () => searchBooks(search.value))
search.onblur = () => {
	setTimeout(() => matchList.style.display = "none", 250);
}