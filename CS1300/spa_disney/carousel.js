document.addEventListener("DOMContentLoaded", () => {
  const DISNEY_API_URL = "https://api.disneyapi.dev/character";
  const disneyCharacterList = document.getElementById("disney-character-links");
  const disneyCharacterCard = document.getElementById("disney-character-card");
  const disneyCharacterName = document.getElementById("disney-character-name");
  const disneyCharacterImage = document.getElementById(
    "disney-character-image"
  );
  const disneyCharacterDetails = document.getElementById(
    "disney-character-details"
  );
  const previousButton = document.getElementById("previous-button");
  const nextButton = document.getElementById("next-button");
  const backButton = document.getElementById("back-button");

  let disneyCharacters = [];
  let currentCharacterIndex = 0;

  async function fetchDisneyCharacters() {
    let pageNumber = 1;
    while (disneyCharacters.length < 100) {
      try {
        const response = await axios.get(
          `${DISNEY_API_URL}?page=${pageNumber}`
        );
        console.log(response.data.data); // Added log for fetched data
        const charactersData = response.data.data;
        disneyCharacters = disneyCharacters.concat(charactersData);
        pageNumber++;
      } catch (error) {
        console.error("Error fetching Disney characters:", error);
        break;
      }
    }
    disneyCharacters = disneyCharacters.slice(0, 100); // Ensure only 100 characters are loaded
    console.log(disneyCharacters); // Added log for character array
    displayDisneyCharacterList();
  }

  function displayDisneyCharacterList() {
    disneyCharacterList.innerHTML = "";
    disneyCharacters.forEach((character, index) => {
      const listItem = document.createElement("li");
      listItem.className = "disney-character-item";
      listItem.innerHTML = `<a href="#" data-character-index="${index}">${character.name}</a>`;
      disneyCharacterList.appendChild(listItem);
    });

    document.querySelectorAll(".disney-character-item a").forEach((link) => {
      link.addEventListener("click", (e) => {
        e.preventDefault();
        currentCharacterIndex = parseInt(link.dataset.characterIndex, 10);
        displayDisneyCharacterCard();
      });
    });
    disneyCharacterList.style.display = "block"; // Ensure the list is displayed
  }

  function displayDisneyCharacterCard() {
    const character = disneyCharacters[currentCharacterIndex];
    disneyCharacterName.textContent = character.name;
    disneyCharacterImage.src = character.imageUrl;
    disneyCharacterDetails.textContent = `TV Shows: ${character.tvShows.join(
      ", "
    )}`;
    toggleControlButtons();
    disneyCharacterList.style.display = "none";
    disneyCharacterCard.style.display = "block";
  }

  function toggleControlButtons() {
    previousButton.disabled = currentCharacterIndex === 0;
    nextButton.disabled = currentCharacterIndex === disneyCharacters.length - 1;
  }

  previousButton.addEventListener("click", () => {
    if (currentCharacterIndex > 0) {
      currentCharacterIndex--;
      displayDisneyCharacterCard();
    }
  });

  nextButton.addEventListener("click", () => {
    if (currentCharacterIndex < disneyCharacters.length - 1) {
      currentCharacterIndex++;
      displayDisneyCharacterCard();
    }
  });

  backButton.addEventListener("click", () => {
    disneyCharacterCard.style.display = "none";
    disneyCharacterList.style.display = "block";
  });

  // Initialize the Disney Character Explorer app
  fetchDisneyCharacters();
});
