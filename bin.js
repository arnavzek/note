if (special && key == 76) {
  e.preventDefault();
  let type = "h1";

  let textData = selection.toString();

  window.mainNode = anchorNode;
  var bold = document.createElement("b");
  bold.appendChild(document.createTextNode(textData));
  console.log(textData, rangeStart, rangeEnd, anchorNode, anchorNode.innerText);

  mainNode.wholeText = removeSomePart(mainNode.wholeText, rangeStart, rangeEnd);
  anchorNode.insertBefore(bold, anchorNode.splitText(rangeStart));
}
s;
