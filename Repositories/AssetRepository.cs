using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly FptFacilityBookingContext _context;

        public AssetRepository(FptFacilityBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            return await _context.Assets
                .Include(a => a.FacilityAssets)
                .ThenInclude(fa => fa.Facility)
                .OrderBy(a => a.AssetName)
                .ToListAsync();
        }

        public async Task<Asset?> GetAssetByIdAsync(int assetId)
        {
            return await _context.Assets
                .Include(a => a.FacilityAssets)
                .ThenInclude(fa => fa.Facility)
                .FirstOrDefaultAsync(a => a.AssetId == assetId);
        }

        public async Task<Asset> CreateAssetAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task<bool> DeleteAssetAsync(int assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null) return false;

            // Check if asset is assigned to any facilities
            var hasAssignments = await _context.FacilityAssets
                .AnyAsync(fa => fa.AssetId == assetId);

            if (hasAssignments)
            {
                throw new InvalidOperationException("Không thể xóa tài sản đang được gán cho phòng. Vui lòng xóa các liên kết trước.");
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssetExistsAsync(int assetId)
        {
            return await _context.Assets.AnyAsync(a => a.AssetId == assetId);
        }

        public async Task<bool> AssetNameExistsAsync(string assetName)
        {
            return await _context.Assets
                .AnyAsync(a => a.AssetName.ToLower() == assetName.ToLower());
        }
    }
}
