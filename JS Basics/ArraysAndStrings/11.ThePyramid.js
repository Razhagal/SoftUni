function calculateConstructionCost(baseSize, stepHeight) {
    // core - stone
    // shell - marble
    // every 5th layeer shell - lapis lazuli
    // final step - gold
    // blocks are 1x1xheight
    // each level is -2 blocks from previous size
    // stone = ((width - 2) * (length - 2)) * stepHeight;
    // outer shell (marble/lapis) = current level (width * 4) - 4 (perimeter)

    const totalPyramidSteps = Math.ceil(baseSize / 2);
    let currentBaseSize = baseSize;
    let totalStoneRequired = 0;
    let totalMarbleRequired = 0;
    let totalLapisRequired = 0;
    let totalGoldRequired = 0;
    for (let i = 1; i <= totalPyramidSteps; i++) {
        const currentShellMaterial = ((currentBaseSize * 4) - 4) * stepHeight;

        if (i < totalPyramidSteps) {
            const currentLevelCoreMaterial = ((currentBaseSize - 2) * (currentBaseSize - 2)) * stepHeight;
            
            totalStoneRequired += currentLevelCoreMaterial;
            if (i % 5 == 0) {
                totalLapisRequired += currentShellMaterial;
            } else {
                totalMarbleRequired += currentShellMaterial;
            }
        } else {
            totalGoldRequired = currentBaseSize == 1 ? (currentBaseSize * stepHeight) : currentShellMaterial;
        }
        
        currentBaseSize -= 2;
    }

    console.log(`Stone required: ${Math.ceil(totalStoneRequired)}`);
    console.log(`Marble required: ${Math.ceil(totalMarbleRequired)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapisRequired)}`);
    console.log(`Gold required: ${Math.ceil(totalGoldRequired)}`);
    console.log(`Final pyramid height: ${Math.floor(totalPyramidSteps * stepHeight)}`);
}

calculateConstructionCost(23, 0.5);