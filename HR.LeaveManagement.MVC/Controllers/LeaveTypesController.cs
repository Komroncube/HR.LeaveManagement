﻿using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;
public class LeaveTypesController : Controller
{
    private readonly ILeaveTypeService _leaveTypeService;

    public LeaveTypesController(ILeaveTypeService leaveTypeService)
    {
        _leaveTypeService = leaveTypeService;
    }

    // GET: LeaveTypesController
    public async Task<ActionResult> Index()
    {
        IEnumerable<LeaveTypeVM> leaveTypes = await _leaveTypeService.GetLeaveTypesAsync();
        return View(leaveTypes);
    }

    // GET: LeaveTypesController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        LeaveTypeVM model = await _leaveTypeService.GetLeaveTypeDetailsAsync(id);

        return View(model);
    }

    // GET: LeaveTypesController/Create
    public async Task<ActionResult> Create()
    {
        return View();
    }

    // POST: LeaveTypesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateLeaveTypeVM leaveTypeVM)
    {
        try
        {
            var response = await _leaveTypeService.CreateLeaveTypeAsync(leaveTypeVM);
            if(response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(leaveTypeVM);
    }

    // GET: LeaveTypesController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        LeaveTypeVM model = await _leaveTypeService.GetLeaveTypeDetailsAsync(id);

        return View(model);
    }

    // POST: LeaveTypesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
    {
        try
        {
            var response = await _leaveTypeService.UpdateLeaveTypeAsync(leaveTypeVM);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(leaveTypeVM);
    }

    
    // POST: LeaveTypesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            Response<int> response = await _leaveTypeService.DeleteLeaveTypeAsync(id);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", response.ValidationErrors);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return BadRequest();
    }
}
