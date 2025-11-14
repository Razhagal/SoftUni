function solve() {
   const townListNodes = document.querySelectorAll('#towns li');
   const searchedText = document.querySelector('#searchText').value.toLowerCase();

   if (searchedText == '') {
      return;
   }

   const filtered = [];
   townListNodes.forEach(t => {
      t.classList.remove('match');
      t.style.fontWeight = 'normal';
      t.style.textDecoration = 'none';

      if (t.textContent.toLowerCase().includes(searchedText)) {
         filtered.push(t);

         t.classList.add('match');
         t.style.fontWeight = 'bold';
         t.style.textDecoration = 'underline';
      }
   });

   document.querySelector('#result').textContent = `${filtered.length} matches found`;
}